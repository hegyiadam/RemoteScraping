import urllib.request
import os
import glob
import time

files = glob.glob('Thumbnails/*')
for f in files:
    os.remove(f)

picture_number = 100
for i in range(picture_number):
    if i%20 = 0:
        time.sleep(5)
    urllib.request.urlretrieve("http://lorempixel.com/300/300", "Thumbnails/"+str(i)+".jpg")
