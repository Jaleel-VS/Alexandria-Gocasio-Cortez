package main

import (
	"fmt"
	"log"
	"os"
)

func main() {
	data, err := readFile("input.txt")
	if err != nil {
		log.Fatalf("could not read file: %v", err)
	}

	floorLevel := 0

	for _, char := range data {
		switch char {
		case '(':
			floorLevel++
		case ')':
			floorLevel--
		}
	}

	fmt.Printf("Santa is on floor %d\n", floorLevel)
}



func readFile(path string) (string, error) {
    data, err := os.ReadFile(path)
    if err != nil {
        return "", err
    }
    return string(data), nil
}