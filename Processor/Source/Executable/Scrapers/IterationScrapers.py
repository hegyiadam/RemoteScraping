class IterationScrapers(object):
    def do_action_on_iteration(url, page_iteration_selector, iteration_number, action,data):
        webpage = Webpage(url)
        webpage.iterate_through_pages(iteration_number,page_iteration_selector)
        func = getattr(CollectorScrapers, action+"_using_webpage")
        return func(webpage,*data)


