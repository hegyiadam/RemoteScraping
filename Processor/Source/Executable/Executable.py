from IExecutable import IExecutable 
from ResultWriter import ResultWriter
from Webpage import Webpage 

class Executable(IExecutable):
    def find_tag_by_css_selector(url, css_selector):
        webpage = Webpage(url)
        Executable.find_tag_by_css_selector_using_webpage(webpage,css_selector)

    def find_tag_by_css_selector2(url, page_iteration_selector, iteration_number, css_selector):
        return Executable.do_action_on_iteration(url,page_iteration_selector,iteration_number,"find_tag_by_css_selector",[css_selector])

    def find_tag_by_css_selector_using_webpage(webpage, css_selector):
        result = webpage.get_element_by_selector(css_selector).get_text()
        url = str(webpage.page_url)
        content = {
            "Url": url,
            "Content":result
        }
        result_writer = ResultWriter()
        result_writer.print_result(content)

    def get_page_numbers(url, page_iteration_selector):
        webpage = Webpage(url)
        return webpage.get_page_numbers(page_iteration_selector)

    def do_action_on_iteration(url, page_iteration_selector, iteration_number, action,data):
        webpage = Webpage(url)
        webpage.iterate_through_pages(iteration_number,page_iteration_selector)
        func = getattr(Executable, action+"_using_webpage")
        return func(webpage,*data)
    
    def get_iteration_links(url, iteration_selector):
        webpage = Webpage(url)
        return Executable.get_iteration_links_using_webpage(webpage,iteration_selector)
    

    def get_iteration_links2(url, page_iteration_selector, iteration_number, iteration_selector):
        return Executable.do_action_on_iteration(url,page_iteration_selector,iteration_number,"get_iteration_links",[iteration_selector])
    
    def get_iteration_links_using_webpage(webpage, iteration_selector):
        links = webpage.get_iteration_links(iteration_selector)
        return links
    
