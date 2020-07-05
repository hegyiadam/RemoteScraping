from IExecutable import IExecutable 

class Executable(IExecutable):
    def reset_data():
        print("reset_data")
    def download_page(url):
        print("reset_data "+str(url))
