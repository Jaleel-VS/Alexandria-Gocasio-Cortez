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

	var floor_level int = 0

	for i := 0; i < len(data); i++ {
		if data[i] == '(' {
			floor_level += 1
		} else {
			floor_level -= 1
		}

	}

	fmt.Printf("Santa is on floor %d\n", floor_level)
}



func readFile(path string) (string, error) {
    data, err := os.ReadFile(path)
    if err != nil {
        return "", err
    }
    return string(data), nil
}