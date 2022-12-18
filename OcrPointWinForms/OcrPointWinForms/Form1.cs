using Newtonsoft.Json;

namespace OcrPointWinForms
{
    public partial class Form1 : Form
    {
        public List<OcrPoint> OcrPoints = new List<OcrPoint>();

        public Form1()
        {
            InitializeComponent();
            LoadJson();
        }

        // LoadTextFromOcrPoints - Load Text from Ocr Points json file
        private void LoadTextFromOcrPoints(PaintEventArgs e)
        {
            foreach (var item in OcrPoints)
            {
                // data is overlapping which has contains "locale" property in json file
                if (item.Locale != null)
                {
                    continue;
                }

                using (Font font1 = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point))
                {
                    var x = item.BoundingPoly.Vertices.Select(a => a.X).Min();
                    var y = item.BoundingPoly.Vertices.Select(a => a.Y).Min();
                    var width = item.BoundingPoly.Vertices.Select(a => a.X).Max() - x;
                    var height = item.BoundingPoly.Vertices.Select(a => a.Y).Max() - y;
                    RectangleF rectF1 = new RectangleF(x, y, width, height);
                    e.Graphics.DrawString(item.Description, font1, Brushes.Blue, rectF1);
                    e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
                }
            }
        }

        private void LoadJson()
        {
            using (StreamReader r = new StreamReader("./ocr.json"))
            {
                string json = r.ReadToEnd();
                OcrPoints = JsonConvert.DeserializeObject<List<OcrPoint>>(json);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            LoadTextFromOcrPoints(e);
        }
    }
}