import cv2
import numpy as np

classificador = cv2.CascadeClassifier('cascades\\haarcascade_frontalface_default.xml')
camera = cv2.VideoCapture(0)
amostra = 1
numero_de_amostras = 25
id = input("Digite seu identificador: ")
largura, altura = 220 , 220
print("Capturando face...")

while True:
    conectado, imagem = camera.read()
    imagemCinza = cv2.cvtColor(imagem, cv2.COLOR_BGR2GRAY) 
    facesDetectadas = classificador.detectMultiScale(imagemCinza, scaleFactor=1.5, minSize=(150, 150))
    #print(np.average(imagemCinza))

    for (x,y,l,a) in facesDetectadas:
        cv2.rectangle(imagem , (x,y), (x+l, y+a), (0,0,255), 2)
        if cv2.waitKey(1) == ord('q'):
            print(np.average(imagemCinza))
            if(np.average(imagemCinza) > 110):
                imagemFace = cv2.resize(imagemCinza[y:y + a, x:x + l], (largura, altura))
                cv2.imwrite("fotos/pessoa_" + str(id) + "_" + str(amostra) + ".jpg", imagemFace)
                print("[Foto" + str(amostra) + "capturada com sucesso]")
                amostra += 1
            else:
                print("Iluminação baixa")

    if (cv2.waitKey(1) == ord('s')):
        print("Execução Terminada")
        break

    cv2.imshow("Face", imagem)
    cv2.waitKey(1)

    if(amostra >= numero_de_amostras + 1):
        print("Faces capturadas com sucesso")
        break


