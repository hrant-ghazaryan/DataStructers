using MySetProj;
using System.Windows;
using System.Windows.Controls;

namespace MySetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Set<Student> _math = new Set<Student>();
        Set<Student> _phys = new Set<Student>();
        Set<Student> _hist = new Set<Student>();

        Set<Student> _men = new Set<Student>();
        Set<Student> _women = new Set<Student>();

        Set<Student> leftSett = new Set<Student>();
        Set<Student> rightSett = new Set<Student>();

        Dictionary<string, Set<Student>> allSets = new Dictionary<string, Set<Student>>();
        List<string> operations = new();
        public MainWindow()
        {
            InitializeComponent();

            Student armen = new Student(1, "Armen", Gender.Male);
            Student jon = new Student(4, "Jon", Gender.Male);
            Student tom = new Student(5, "Tom", Gender.Male);
            Student bob = new Student(7, "Bob", Gender.Male);
            Student armenuhi = new Student(2, "Armenuhi", Gender.Female);
            Student marieta = new Student(3, "Marieta", Gender.Female);
            Student sara = new Student(6, "Sara", Gender.Female);
            Student jenifer = new Student(8, "Jenifer", Gender.Female);
            Student davit = new Student(9, "David", Gender.Male);
            Student kamo = new Student(10, "Kamo", Gender.Male);
            Student varuj = new Student(11, "Varuj", Gender.Male);
            Student manushak = new Student(12, "Manushak", Gender.Female);
            Student sahak = new Student(13, "Sahak", Gender.Male);
            Student mnacakan = new Student(14, "Mnacakan", Gender.Male);
            Student lyudvig = new Student(15, "Lyudvig", Gender.Male);
            Student sanasar = new Student(16, "Sanasar", Gender.Female);

            _women.AddRange(new Student[] { armenuhi, marieta, sara, jenifer });
            _men.AddRange(new Student[] { armen, jon, tom, bob });
            _math.AddRange(new Student[] { sanasar, sahak, manushak, tom, armen, jenifer });
            _phys.AddRange(new Student[] { varuj, davit, kamo, sara, jenifer, armenuhi, bob, tom });
            _hist.AddRange(new Student[] { marieta, sahak, manushak, sara, jenifer, mnacakan, bob, jon });

            allSets.Add("Men", _men);
            allSets.Add("Women", _women);
            allSets.Add("Math", _math);
            allSets.Add("Physic", _phys);
            allSets.Add("History", _hist);

            foreach (var key in allSets.Keys)
            { rightSet.Items.Add(key); leftSet.Items.Add(key); }

            operations.AddRange(new string[] { "Union", "Intersection", "Difference", "SymetricDifference" });
            foreach (var item in operations)
                operation.Items.Add(item);

        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            /*resultSet.Items.Clear();
            Set<Student> resultSett = new();

            if (leftSett is null || rightSett is null) return;

            switch (operation.SelectedItem)
            {
                case "Union":
                    resultSett = leftSett.Union(rightSett);
                    break;
                case "Intersection":
                    resultSett = leftSett.Intersection(rightSett);
                    break;
                case "Difference":
                    resultSett = leftSett.Difference(rightSett);
                    break;
                case "SymetricDifference":
                    resultSett = leftSett.SymetricDifference(rightSett);
                    break;
            }

            foreach (var item in resultSett)
                resultSet.Items.Add(item.Name);*/

            resultSet.Items.Clear();

            if (leftSett is null || rightSett is null) return;

            var operationn = new Dictionary<string, Func<Set<Student>, Set<Student>, Set<Student>>>
            {
                {"Union" , (a,b) => a.Union(b) },
                {"Intersection" , (a,b) => a.Intersection(b) },
                {"Difference" , (a,b) => a.Difference(b) },
                {"SymetricDifference" , (a,b) => a.SymetricDifference(b) }
            };

            string? op = operation.SelectedItem as string;
            if (op is null || !operationn.TryGetValue(op, out var func)) return;

            var result = func(leftSett, rightSett);

            foreach (var item in result)
                resultSet.Items.Add(item.Name);
        }

        private void leftSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            leftMembers.Items.Clear();

            string? key = leftSet.SelectedItem as string;
            if (key is not null && allSets.TryGetValue(key, out Set<Student>? leftList))
            {
                foreach (var item in leftList)
                    leftMembers.Items.Add(item.Name);
                leftSett = leftList;
            }
        }
        private void rightSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rightMembers.Items.Clear();

            string? key = rightSet.SelectedItem as string;
            if (key is not null && allSets.TryGetValue(key, out Set<Student>? rightList))
            {
                foreach (var item in rightList)
                    rightMembers.Items.Add(item.Name);
                rightSett = rightList;
            }
        }
    }
}