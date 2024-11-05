namespace Simulator
{
    public class Animals
    {

        private string _description="Unknown";
        public string Description
        {
            get => _description;
            init
            {
                string trdescription = value.Trim();

                if (trdescription.Length < 3)
                {
                    trdescription = trdescription.PadRight(3, '#');
                }
                if (trdescription.Length > 15)
                {
                    trdescription = trdescription.Substring(0, 15).TrimEnd();

                    if (trdescription.Length < 3)
                    {
                        trdescription = trdescription.PadRight(3, '#');
                    }
                }
                if (char.IsLower(trdescription[0]))
                {
                    trdescription = char.ToUpper(trdescription[0]) + trdescription.Substring(1);
                }

                _description = trdescription;
            }
        }
        public int Size { get; set; } = 3;
        public string Info => $"{Description} <{Size}>";
    }
}