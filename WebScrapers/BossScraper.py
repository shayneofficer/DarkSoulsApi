from bs4 import BeautifulSoup as bsoup
import requests

start_url = 'https://darksouls.wiki.fextralife.com/Bosses'

downloaded_html = requests.get(start_url)
soup = bsoup(downloaded_html.text)
print(soup.text)

