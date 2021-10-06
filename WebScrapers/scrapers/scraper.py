""" Defines scrapers """
from dataclasses import dataclass

from bs4 import BeautifulSoup
import requests


@dataclass
class URI_TYPES:
  ENEMIES = 'Enemies'
  BOSSES = 'Bosses'


def scrape(base_url: str, uri: str) -> list:
  """ Scrape data at base_url/uri

  :params base_url: Base URL we want to scrape
  :type base_url: str
  :params uri: Current URI to consider for scraping - must be one of URI_TYPES
  :type uri: str
  :returns: List of entities
  :rtype: list
  """
  url = f'{base_url}/{uri}'
  page = requests.get(url)
  soup = BeautifulSoup(page.content, 'html.parser')

  if uri == URI_TYPES.ENEMIES:
    return scrape_enemy_info(soup, base_url)
  elif uri == URI_TYPES.BOSSES:
    # return scrape_boss_info(soup, base_url)
    pass

def scrape_table(link_soup):
  """"""
  table_headers = link_soup.find('table', {'class': 'wiki_table'}).find_all('th')
  entity_name, other_headers = table_headers[0], table_headers[1:]
  try:
    entity_name = entity_name.find('h3').text
  except:
    try:
      entity_name = entity_name.find('h2').text
    except:
      entity_name = entity_name.text
  table_data = link_soup.find('table', {'class': 'wiki_table'}).find_all('td')
  # Discard first element; it's useless - THIS IS AN ASSUMPTION
  relevant_data = [datum.text for datum in table_data[1:]]

  entity_attributes = {
    'name': entity_name
  }
  for header, datum in zip(other_headers, relevant_data):
    for child in header.children:
      try:
        key = str(child.get('title'))
      except:
        key = str(child)
    entity_attributes[key] = datum

  return entity_attributes


def scrape_link(link: str, base_url: str):
  """"""
  url = f"{base_url}{link['href']}"
  page = requests.get(url)
  if page.status_code != 200:
    return {}

  link_soup = BeautifulSoup(page.content, 'html.parser')
  return scrape_table(link_soup)


def scrape_list_item(list_item, base_url: str):
  """"""
  link = list_item.find('a', href=True)
  return scrape_link(link, base_url)


def scrape_enemy_info(soup: BeautifulSoup, base_url: str) -> list:
  """ Scrape enemy

  :params soup: BeautifulSoup instance containing page info
  :type soup: BeautifulSoup
  :params base_url: URL for appending
  :type base_url: str
  :returns: List of enemy info
  :rtype: list
  """
  return [
    scrape_list_item(list_item, base_url)
    for list_item
    in soup.find('div', { 'id': 'wiki-content-block' }).find_all('li')
  ]
