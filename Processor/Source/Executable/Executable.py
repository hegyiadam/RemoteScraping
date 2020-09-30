from IExecutable import IExecutable 
from ResultWriter import ResultWriter
from Webpage import Webpage 

class Executable(IExecutable):
    def find_tag_by_css_selector(url, css_selector):
        webpage = Webpage(url)
        ResultWriter.print_result(webpage.get_element_by_selector(css_selector))
    def find_page_iteration(url, css_selector):
        webpage = Webpage(url)
        ResultWriter.print_result(webpage.get_elements_by_selector(css_selector))
