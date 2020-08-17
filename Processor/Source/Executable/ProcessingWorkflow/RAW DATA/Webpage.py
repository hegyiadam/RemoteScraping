from RawData import RawData
import urllib.request
from bs4 import BeautifulSoup


class Webpage(RawData):
    def __init__(self, url):
        self.url = url
        self.content = download_page(url)

    def download_page(url):
        response = urllib2.urlopen(url)
        html = response.read()
        return html

    def get_url():
        return self.url
    def set_url(url):
        self.url = url
        self.content = download_page(url)
        
    def get_content():
        return self.content
    def get_soup():
        return BeautifulSoup(get_content(), 'html.parser')
