import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.neural_network import MLPClassifier

url = 'https://archive.ics.uci.edu/ml/machine-learning-databases/glass/glass.data'
dataset = pd.read_csv(url, header=None)
print(dataset)

names = ['Id', 'RI', 'Na', 'Mg', 'Al', 'Si',
         'K', 'Ca', 'Ba', 'Fe', 'glass_type']
dataset.columns = names

print(dataset[['Id', 'RI', 'Na', 'Mg', 'Al', 'Si',
               'K', 'Ca', 'Ba', 'Fe', 'glass_type']])

Xdata = dataset[['Id', 'RI', 'Na', 'Mg', 'Al', 'Si',
                 'K', 'Ca', 'Ba', 'Fe', 'glass_type']]

Ydata = dataset[["glass_type"]]

X_train, X_test, y_train, y_test = train_test_split(
    Xdata, Ydata, test_size=0.3)

print(str(X_train.shape))
print(str(X_test.shape))
print(str(y_train.shape))
print(str(y_test.shape))

NN = MLPClassifier()
NN.fit(X_train, y_train)
TestScore = NN.score(X_test, y_test)

print(TestScore)

print("O Algortimo MLP teve um acurácia de " + str(TestScore*100) + "%")
