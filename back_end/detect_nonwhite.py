# import packages
import numpy as np
import argparse
import cv2

# Argument parser
ap = argparse.ArgumentParser()
ap.add_argument("-i", "--image", help="path to the image")
args = vars(ap.parse_args())

lower = [0, 0, 0]
upper = [145, 133, 128]

lower = np.array(lower, dtype = "uint8")
upper = np.array(upper, dtype = "uint8")

# load image
image = cv2.imread(args["image"])

mask = cv2.inRange(image, lower, upper)
output = cv2.bitwise_and(image, image, mask = mask)

blackcount = cv2.countNonZero(mask)


print(blackcount)

cv2.imshow("images", np.hstack([image, output]))
cv2.waitKey(0)


