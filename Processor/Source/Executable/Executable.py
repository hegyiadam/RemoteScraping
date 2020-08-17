from IExecutable import IExecutable 
from Webpage import Webpage 
from bs4 import BeautifulSoup
import urllib

class Executable(IExecutable):
    def reset_data():
        print("reset_data")
    def download_page(url):
        Webpage(url)
        return Webpage.get_content()
    def find_tag_by_css_selector(css_selector):
        print("reset_data "+str(url))
