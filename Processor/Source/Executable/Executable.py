from IExecutable import IExecutable 
from ResultWriter import ResultWriter
from Webpage import Webpage 

class Executable(IExecutable):
    def find_tag_by_css_selector(url, css_selector):
        webpage = Webpage(url)
        find_tag_by_css_selector(webpage,css_selector)

    def find_tag_by_css_selector(webpage, css_selector):
        ResultWriter.print_result(webpage.get_element_by_selector(css_selector))
    def get_page_numbers(url, page_iteration_selector):
        webpage = Webpage(url)
        return webpage.get_page_numbers(page_iteration_selector)
    def do_action_on_iteration(url, page_iteration_selector, iteration_number, action,data):
        webpage = Webpage(url)
        webpage.iterate_through_pages(iteration_number,page_iteration_selector)
        func = getattr(Executable, action)
        func(webpage,*data)
    def get_iteration_links(url, iteration_selector):
        webpage = Webpage(url)
        links = webpage.get_iteration_links(iteration_selector)
        return links
    
