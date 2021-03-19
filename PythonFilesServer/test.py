import tensorflow as tf
import numpy as np
import pickle
import cv2
import csv

model = tf.keras.models.load_model('my_model.h5')

pickle_in = open("X.pickle","rb")
X = pickle.load(pickle_in)

pickle_in = open("y.pickle","rb")
y = pickle.load(pickle_in)


def prepare(filepath):
    IMG_SIZE = 50
    img_array = cv2.imread(filepath, cv2.IMREAD_GRAYSCALE)
    new_array = cv2.resize(img_array, (IMG_SIZE, IMG_SIZE))
    return new_array.reshape(-1, IMG_SIZE, IMG_SIZE, 1)

g=prepare("img.png")
print(model.predict(g)[0][0])
'''l=model.predict(X)
print(l)
print(min(l))
print(max(l))'''
'''pickle_in = open("y.pickle","rb")
y = pickle.load(pickle_in)
l=[]
pickle_in = open("X.pickle","rb")
X = pickle.load(pickle_in)
X=X/255.0
y=np.array(y)
print(len(y))
print(len(X))

for i in y:
    l.append(i)

print(y[5])

with open("Y.csv", "w", newline="") as file:
    writer = csv.writer(file)
    writer.writerows(l)'''
