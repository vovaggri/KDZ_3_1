namespace ClassLibrary;
/// <summary>
/// Класс клиента.
/// </summary>
public class Customer
{
    // Конструктор без параметров.
    public Customer()
    {
    }

    // Конструктор с параметрами.
    public Customer(int cust_id, string name, string email, int age,
        string city, bool isPremium, string[] purchases)
    {
        _customer_id = cust_id;
        _name = name;
        _email = email;
        _age = age;
        _city = city;
        _is_premium = isPremium;
        _purchases = purchases;
    }

    // Поля.
    private int _customer_id;
    private string _name;
    private string _email;
    private int _age;
    private string _city;
    private bool _is_premium;
    private string[] _purchases;

    // Свойства для чтения.
    public int Customer_ID { get { return _customer_id; } }
    public string Name { get { return _name; } }
    public string Email { get { return _email; } }
    public int Age { get { return _age; } }
    public string City { get { return _city; } }
    public bool Is_Premium { get { return _is_premium; } }
    public string[] Purchases { get { return _purchases; } }
}