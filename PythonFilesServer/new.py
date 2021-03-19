import numpy as np
import matplotlib.pyplot as plt
import os
import cv2
from tqdm import tqdm
from PIL import Image
from io import BytesIO
import random
import pickle

DATADIR = "TrainSet"

X = np.load('dataX.npy')
y = np.load('dataY.npy')

imgSize=50
def genImg(count):
    for i in X:
        image = Image.open(BytesIO(i))
        image.save(DATADIR+"/"+'Car'+str(count)+".png")
        count+=1
#genImg(0)
training_data = []

def create_training_data():
    i=0
    for img in tqdm(os.listdir(DATADIR)):
        try:
            img_array = cv2.imread(os.path.join(DATADIR,img) ,cv2.IMREAD_GRAYSCALE)
            new_array = cv2.resize(img_array, (imgSize, imgSize))
            z=(y[i]+1)/2
            training_data.append([new_array, z])
        except Exception as e:
            pass
        i+=1
    

create_training_data()


random.shuffle(training_data)


X = []
y = []

for features,label in training_data:
    X.append(features)
    y.append(label)

X = np.array(X).reshape(-1, imgSize, imgSize, 1)

pickle_out = open("X.pickle","wb")
pickle.dump(X, pickle_out)
pickle_out.close()

pickle_out = open("y.pickle","wb")
pickle.dump(y, pickle_out)
pickle_out.close()

pickle_in = open("X.pickle","rb")
X = pickle.load(pickle_in)
print(X)

pickle_in = open("y.pickle","rb")
y = pickle.load(pickle_in)
print(y)
print(min(y))
print(max(y))