# Advent of Code Practice: 2015-2025

Welcome to my Advent of Code journey! 🎄✨ This repository contains my solutions for Advent of Code challenges from **2015 to 2025**, written in **GoLang**. It's a fun way to practice problem-solving, learn GoLang, and enhance my coding skills in these languages.

## Progress Overview

Below is a progress tracker for each year's challenges. Each year has 25 problems, and my progress is displayed using a neat progress bar.

| Year | Go Status |
|------|-------------|
| 2015 | 1/25 🛠️ |
| 2016 | 0/25 🛠️ |
| 2017 | 0/25 🛠️ |
| 2018 | 0/25 🛠️ |
| 2019 | 0/25 🛠️ |
| 2020 | 0/25 🛠️ |
| 2021 | 0/25 🛠️ |
| 2022 | 0/25 🛠️ |
| 2023 | 0/25 🛠️ |
| 2024 | 0/25 🛠️ |
| 2025 | 0/25 🛠️ |

---



```golang
// boilerplate
// read files line by line

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

// parts
func solvePart1(lines []string) int {
    fmt.Println("Part 1 is not yet implemented.")
    return 0

func solvePart2(lines []string) int {
	fmt.Println("Part 2 is not yet implemented.")
	return 0
}
// main
var part = flag.Int("part", 1, "which part to solve (1 or 2)")
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

```