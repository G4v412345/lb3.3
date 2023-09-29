namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private List<Shape> sh = new List<Shape>();
        public Form1()
        {
            InitializeComponent();

            sh.Add(new Circle(10));
            sh.Add(new Rectangles(2, 4));
            foreach (var shape in sh)
            {
                listBox1.Items.Add(shape.GetType().Name);
            }
        }
        public interface shapevisitor
        {
            void Visit(Circle circle);
            void Visit(Rectangles rectangles);
        }
        public abstract class Shape
        {
            public abstract void Accept(shapevisitor visitor);
        }
        public class Circle : Shape
        {
            public double R { get; }
            public Circle(double R)
            {
                this.R = R;
            }
            public override void Accept(shapevisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        public class Rectangles : Shape
        {
            public double w { get; }
            public double h { get; }

            public Rectangles(double w, double h)
            {
                this.w = w;
                this.h = h;
            }
            public override void Accept(shapevisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        public class Visitor : shapevisitor
        {
            public double area { get; private set; }
            public double p { get; private set; }

            public void Visit(Circle circle)
            {
                area = Math.PI * circle.R * circle.R;
                p = 2 * Math.PI * circle.R;
            }
            public void Visit(Rectangles rectangles)
            {
                area = rectangles.w * rectangles.h;
                p = 2 * (rectangles.w + rectangles.h);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                Shape selectShape = sh[index];
                Visitor visitor = new Visitor();
                selectShape.Accept(visitor);

                textBox1.Text = $"S: {visitor.area}, P: {visitor.p}";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}