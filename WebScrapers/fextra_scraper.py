""" Main driver """
import json

from scrapers import scrape


def main():
  """ Main driver for the scraper """
  BASE_URL = 'https://darksouls.wiki.fextralife.com'
  
  enemy_info = scrape(BASE_URL, 'Enemies')
  print(json.dumps(enemy_info))
  #bosses_info = scrape(BASE_URL, 'Bosses')


# Run it
main()
