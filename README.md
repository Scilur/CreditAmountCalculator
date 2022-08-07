# Test Application "Credit Amount Calculation"

##### Description:
Develop a class for calculating the maximum amount of credit available to the Person according to his Score.

The Score is calculated as a Sum of points accepted from several different aspects:

- Points are provided according to the Person's age:

| Min Age | Max Age | Score points |
| :-------: | :-------: | :------------: |
| 16 | 25 | 10 |
| 26 | 50 | 30 |
| 51 | 60 | 20 |
| 61 |    | -50 |

- Points are provided according to the Credit Rank of the Person

| From Rank | To Rank | Score points |
| :-------: | :-------: | :------------: |
| 0 | 30 | -30 |
| 31 | 70 | 0 |
| 71 | 100 | 30 |

- If the Person has family it adds **10** points to his Score
- If the Person has Stationar Phone number it adds **5** points to his Score
- If the Person has Visas it adds **5** points to his Score
- If the Person has own House it adds **15** points to his Score
- If the Person has own Car it adds **15** points to his Score
- If the Person was Convicted it substructs **-30** points to his Score
- If the Person yas Another Credit it substructs **-20** points to his Score

The minimum possible Score is 0 and the Maximum is 100. If the Person Score is less or higher than these boundaries then the Score must be corrected to be inside this range.

The Maximum Credit Amount is calculated on the basis of the Score:

| Min Score | Max Score | Maximum Credit Amount |
| :-------: | :-------: | :------------: |
| 0 | 20 | 0.00 |
| 21 | 60 | 1000.00 |
| 61 | 80 | 10000.00 |
| 81 | 100 | 50000.00 |
