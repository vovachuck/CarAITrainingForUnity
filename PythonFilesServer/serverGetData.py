import time
import zmq
from PIL import Image
from io import BytesIO
import os
import cv2 as cv
import numpy as np
import csv
import msvcrt
import numpy as np


context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

listTestX=[]
listTestY=[]
i=1
while True:
    message = socket.recv()
    
    if message!=None:
        
        try:
            #print(message)
            if str(message)=="b'stop'":
                print("stop")
                socket.send(b"World")
                break
            i+=1
            if i%2==0:
                image = Image.open(BytesIO(message))
                #print("Received request: %s" % int.from_bytes(message,"big"))
                #x = img_to_array(image)
                '''image.save('img.png')
                img = cv.imread('img.png')
                img = cv.resize(img,(256,256))
                img = np.reshape(img,[1,256,256,3])'''
                listTestX.append(message)
            else:
                message=str(message)
                message=message.replace(",", ".")
                value=float(message[2:message.rfind("'")])
                #print(value) #get Input Value
                listTestY.append(value)
            socket.send(b"World")

        except Exception as e:
            print("Some Error  "+ str(e))
            socket.send(b"World")
    
    #time.sleep(1)
a=np.array(listTestX)
#y = np.load('dataX.npy')
#z=np.append(y, a)
np.save('dataX.npy', a)

a=np.array(listTestY)
#y = np.load('dataY.npy')
#z=np.append(y, a)
np.save('dataY.npy', a)
print(len(a))
    
    
    
