from LocationContainer import LocationContainer

class ResultWriter(object):
    def print_result(result):
        result_file_name = "result.txt"
        file_path = LocationContainer.get_result_location() +"\\"+ result_file_name
        ResultWriter.write_to_file(file_path,str(result))
    def write_to_file(path, content):
        with open(path, "a") as f:
            f.write(content)
    def get_result(filename):
        file_path = LocationContainer.get_result_location() +"\\"+ filename
        f = open(file_path,) 
        data = f.read()
        f.close()
        return data

