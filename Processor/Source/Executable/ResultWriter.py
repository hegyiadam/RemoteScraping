from LocationContainer import LocationContainer
import pymongo

class ResultWriter(object):
    def print_result(result):
        #result_file_name = "result.txt"
        #file_path = LocationContainer.get_result_location() +"\\"+ result_file_name
        ResultWriter.write_to_db(result)
    def write_to_file(path, content):
        with open(path, "a") as f:
            f.write(content)
    def write_to_db(content):
        myclient = pymongo.MongoClient("mongodb://localhost:27017/")
        mydb = myclient["RemoteScrape"]
        mycol = mydb["currentsessionresults"]
        mycol.insert_one(content)

    def get_result(filename):
        file_path = LocationContainer.get_result_location() +"\\"+ filename
        f = open(file_path,) 
        data = f.read()
        f.close()
        return data

