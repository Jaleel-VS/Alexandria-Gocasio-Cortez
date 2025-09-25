package main

import (
	"bufio"
	"flag"
	"fmt"
	"log"
	"os"
)

var part = flag.Int("part", 1, "run part 1 or 2")

func main() {
	flag.Parse()

	lines, err := readLines("input.txt")
	if err != nil {
		log.Fatalf("could not read file: %v", err)
	}
	switch *part {
	case 1:
		answer := solvePart1(lines)
		fmt.Println("Part 1 Answer:", answer)
	case 2:
		answer := solvePart2(lines)
		fmt.Println("Part 2 Answer:", answer)
	default:
		log.Fatalf("invalid part number: %d", *part)
	}
}

func solvePart1(lines []string) int {
	floorLevel := 0
	for _, char := range lines[0] {
		switch char {
		case '(':
			floorLevel++
		case ')':
			floorLevel--
		}
	}
	return floorLevel
}

func solvePart2(lines []string) int {
	floorLevel := 0

	for i, char := range lines[0] {
		switch char {
		case '(':
			floorLevel++
		case ')':
			floorLevel--
		}

		if floorLevel == -1 {
			return i + 1
		}
	}

	return 0
}



func readLines(path string) ([]string, error) {
	file, err := os.Open(path)
	if err != nil {
		return nil, err
	}

	defer file.Close()

	var lines []string

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}

	return lines, scanner.Err()
}