import json 
  

settings_file_location = '..\..\_Globals\settings.json'

class LocationContainer(object):
    def get_result_location():
        data = LocationContainer.read_settings_file(settings_file_location)
        print(data)
        return data['result_location']

    def read_settings_file(file_path):
        f = open(file_path,) 
        data = json.load(f) 
        f.close()
        return data

