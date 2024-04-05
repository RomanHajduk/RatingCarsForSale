namespace RatingCarsForSale
{
    public class Statistics
    {

        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                if (Count == 0)
                {
                    return 0;
                }
                else
                {
                    return (float)Sum / Count;
                }

            }
        }
        public Statistics()
        {
            this.Min = 0;
            this.Max = 0;
            this.Sum = 0;
            this.Count = 0;
            
        }
        public char AverageLetter
        {
            get
            {
                switch (this.Average)
                {
                    case >= 8:
                        return 'A';
                    case >= 6:
                        return 'B';
                    case >= 4:
                        return 'C';
                    case >= 2:
                        return 'D';
                    default:
                        if (this.Count == 0)
                        {
                            return ' ';
                        }
                        else
                        {
                            return 'E';
                        }

                }
            }
        }

        public void AddGrade(int grade)
        {

            this.Sum += grade;
            if (this.Count == 0)
            {
                this.Min = 10;
                this.Min = Math.Min(grade, this.Min);
            }
            else
            {
                this.Min = Math.Min(grade, this.Min);
            }
            this.Count++;
            this.Max = Math.Max(grade, this.Max);

        }
    }
}