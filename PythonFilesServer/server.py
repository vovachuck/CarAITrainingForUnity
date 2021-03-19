import time
import zmq
from PIL import Image
from io import BytesIO
import os
import cv2
import numpy as np
import tensorflow as tf

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

model = tf.keras.models.load_model('model2.h5')

def prepare(nparr):
    IMGSIZE = 50
    imgArray = cv2.imdecode(nparr, cv2.IMREAD_GRAYSCALE)
    newArray = cv2.resize(imgArray, (IMGSIZE, IMGSIZE))
    return newArray.reshape(-1, IMGSIZE, IMGSIZE, 1)

while True:
    message = socket.recv()
    
    if message!=None:
        try:
            nparr = np.frombuffer(message, np.uint8)
            res=prepare(nparr)
            predict=model.predict(res)[0][0]
            predict=(2*predict-1)*1.8
            print(predict)
            socket.send(str(predict).encode('utf-8'))
            print("send")

        except Exception as e:
            print("Some Error  "+ str(e))
            socket.send(b"error")

    
    
    #time.sleep(1)
    
    
    
