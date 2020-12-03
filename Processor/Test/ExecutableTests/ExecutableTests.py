import unittest
from Executable import Executable
from ResultWriter import ResultWriter
from MongoHandler import MongoHandler


class ExecutableTests(unittest.TestCase):
    def setUp(self):
        self.mongo_handler = MongoHandler()
        self.mongo_handler.clear_results()

    def test_find_tag_by_css_selector(self):
        expected = 'RemoteScraping Test Site'
        url = "http://www.localhost:3000"
        selector = "#root > div > header > h1"

        Executable.find_tag_by_css_selector(url,selector)

        actual = self.get_result_content();
        self.assertEqual(expected, actual)

    def test_get_iteration_links(self):
        expected = ['http://www.localhost:3000/topic/0', 'http://www.localhost:3000/topic/1', 'http://www.localhost:3000/topic/2', 'http://www.localhost:3000/topic/3'];
        url = "http://www.localhost:3000"
        selector = "#root > DIV > BODY > DIV > DIV > DIV > DIV > H3 > A"

        actual = Executable.get_iteration_links(url,selector)

        self.assertEqual(expected, actual)
        
    def test_get_page_numbers(self):
        expected = [1, 2, 3]
        url = "http://www.localhost:3000"
        selector = "#root > DIV > BODY > DIV > UL > LI"

        actual = Executable.get_page_numbers(url,selector)

        self.assertEqual(expected, actual)


    def get_result_content(self):
        result_cursor = self.mongo_handler.find_results()
        return result_cursor[0]["Content"]


if __name__ == '__main__':
    unittest.main()