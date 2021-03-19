import tensorflow as tf
from tensorflow.keras.datasets import cifar10
from tensorflow.keras.preprocessing.image import ImageDataGenerator
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Dropout, Activation, Flatten
from tensorflow.keras.layers import Conv2D, MaxPooling2D
import numpy as np
import pickle
import cv2
import random
#from tensorflow.keras.callbacks import TensorBoard

NAME = "CarAI"

#tensorboard = TensorBoard(log_dir="logs/{}".format(NAME))

pickle_in = open("X.pickle","rb")
X = pickle.load(pickle_in)

pickle_in = open("y.pickle","rb")
y = pickle.load(pickle_in)

model = Sequential()

model.add(Conv2D(256, (3, 3), input_shape=X.shape[1:]))
model.add(Activation('relu'))
model.add(MaxPooling2D(pool_size=(2, 2)))

model.add(Conv2D(256, (3, 3)))
model.add(Activation('relu'))
model.add(MaxPooling2D(pool_size=(2, 2)))

model.add(Flatten())

model.add(Dense(128))
model.add(Activation('relu'))

model.add(Dense(1))


model.compile(loss='mse',
              optimizer='adam',
              metrics=['mae'])

y=np.array(y)

'''Z=X[4].reshape(-1,50,50,1)

print(model.predict(Z))
print(y[30])'''
model.fit(X, y, batch_size=2, epochs=3, validation_split=0.3)
model.save('model3.h5')

'''print(model.predict(Z))
l=model.predict(X)
print(l)
print(max(l))
print(min(l))'''
