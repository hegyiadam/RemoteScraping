import unittest
from Executable import Executable
from ResultWriter import ResultWriter
from LocationContainer import LocationContainer


class ExecutableTests(unittest.TestCase):
    def test_find_tag_by_css_selector(self):
        Executable.find_page_iteration()
        result = ResultWriter.get_result("result.txt");
        self.assertFalse(result == "")
        
class LocationContainerTests(unittest.TestCase):
    def test_get_result_location(self):
        result = LocationContainer.get_result_location()
        self.assertFalse(result == "")


if __name__ == '__main__':
    unittest.main()