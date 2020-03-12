import cv2

print(cv2.__version__)

path = ("C:/Users/famil/Downloads/opencv-python.jpg")
imagem = cv2.imread(path)
imagemCinza = cv2.cvtColor(imagem, cv2.COLOR_BGR2GRAY)
cv2.imshow("original", imagem)
cv2.imshow("Cinza", imagemCinza)
cv2.waitKey()