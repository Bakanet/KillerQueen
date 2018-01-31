def biscuit(i, j, M, length):
	maximum = M[i][j]
	direction = j

	if j > 0 and M[i][j-1] > maximum:
		maximum = M[i][j-1]
		direction = j-1
	if j < length - 1 and M[i][j+1] > maximum:
                maximum = M[i][j+1]
                direction = j+1
	
	return (maximum, direction)

def glouton(M):
	lineLength = len(M)
	colLength = len(M[0])
	maxi = M[0][0]
	j = 0
	points = 0

	for i in range(1, colLength):
		if M[0][i] > maxi:
			maxi = M[0][i]
			j = i

	points += maxi
	
	for i in range(1, lineLength):
		(maxi, direction) = biscuit(i, j, M, colLength)
		points += maxi
		j = direction
	
	return points

matrix = [[3, 1, 7, 4, 2], [2, 1, 3, 1, 1], [1, 2, 2, 1, 8], [2, 2, 1, 5, 3], [2, 1, 4, 4, 4], [5, 2, 7, 5, 1]]
print(glouton(matrix))
