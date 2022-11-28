#include <iostream>
#include <string>
#include <map>
#include <regex>
#include <sstream>
#include <stack>
#include <iterator>
#include <algorithm>

using namespace std;

int setOrder(char operation)
{
  if (operation < 0)
    return 4;
  if (operation == '-')
    return 3;
  if (operation == '+')
    return 1;
  if (operation == '*')
    return 2;
  return -1;
}

void process(stack<int> &numbers, char operation)
{
  if (operation < 0)
  {
    int num = numbers.top();
    numbers.pop();
    if (-operation == '+')
    {
      numbers.push(num);
    }
  }
  else if (operation == '-')
  {
    int top = numbers.top();
    numbers.pop();
    numbers.push(!top);
  }
  else
  {
    int num1 = numbers.top();
    numbers.pop();
    int num2 = numbers.top();
    numbers.pop();

    if (operation == '+')
    {
      numbers.push(num2 | num1);
    }
    else if (operation == '*')
    {
      numbers.push(num2 & num1);
    }
    else
    {
      cout << "Error: Invalid string" << endl;
    }
  }
}

int process(string &s)
{
  stack<int> numbers;
  stack<char> operators;
  bool check_pos = true;
  int count = 1;
  for (int i = 0; i < (int)s.size(); i++)
  {
    count = 1;
    if (s[i] == ' ')
      continue;

    if (s[i] == '(')
    {
      operators.push('(');
      check_pos = true;
    }
    else if (s[i] == ')')
    {

      while (operators.top() != '(')
      {
        process(numbers, operators.top());
        operators.pop();
        if (operators.empty())
        {
          return -1;
        }
      }
      operators.pop();
      check_pos = false;
    }
    else if (s[i] == '+' || s[i] == '*' || (s[i] == '-' && s[i + 1] == '('))
    {
      char op = s[i];

      if (check_pos && op == '+')
        op = -op;
      while (!operators.empty() && ((op >= 0 && setOrder(operators.top()) >= setOrder(op)) ||
                                    (op < 0 && setOrder(operators.top()) > setOrder(op))))
      {

        process(numbers, operators.top());
        operators.pop();
      }
      operators.push(op);
      check_pos = true;
    }
    else
    {
      if (s[i] == '-')
      {
        {
          while (!(s[i + 1] == '0' || s[i + 1] == '1' || s[i+1] == '('))
          {
            if (s[i + 1] == '-')
            {
              count++;
              i++;
            }
            else
            {
              return -1;
            }
          }
        }
        if (s[i + 1] == '0')
        {
          if (count % 2 == 0)
          {
            numbers.push(0);
          }
          else
          {
            numbers.push(1);
          }
        }
        else if (s[i + 1] == '1')
        {
          if (count % 2 == 0)
          {
            numbers.push(1);
          }
          else
          {
            numbers.push(0);
          }
        }
        else if (count % 2 != 0)
        {
          char op = s[i];
          if (check_pos && op == '+')
            op = -op;
          while (!operators.empty() && ((op >= 0 && setOrder(operators.top()) >= setOrder(op)) ||
                                        (op < 0 && setOrder(operators.top()) > setOrder(op))))
          {

            process(numbers, operators.top());
            operators.pop();
          }
          operators.push(op);
          check_pos = true;
          i--;
        }
        else{
          i--;
        }
        
        i++;
      }
      else
      {
        if (s[i] == '0')
        {
          numbers.push(0);
        }
        else if (s[i] == '1')
        {
          numbers.push(1);
        }
        else
          return -1;
      }

      check_pos = false;
    }
  }

  while (!operators.empty())
  {
    process(numbers, operators.top());
    operators.pop();
  }
  if (numbers.size() != 1)
  {
    return -1;
  }
  return numbers.top();
}

int checkBalance(string &s)
{
  stack<char> balancedParam;
  for (int i = 0; i < (int)s.size(); i++)
  {

    if (s[i] == '(')
    {
      // Push the element in the stack
      balancedParam.push(s[i]);
    }
    else if (s[i] == ')')
    {
      if (!balancedParam.empty() && balancedParam.top() == '(')
      {
        balancedParam.pop();
      }
      else
      {
        return -1;
      }
    }
  }
  if (!balancedParam.empty())
  {
    return -1;
  }
  return 0;
}

int main()
{
  string line;
  while (getline(cin, line))
  {
    try
    {
      // lets remove all spaces first
      line.erase(remove(line.begin(), line.end(), ' '), line.end());
      // string matches base format, lets try and separate formula and assignment
      if (line.find(";") != string::npos)
      {
        string formulaStr;
        string assignmentStr;

        stringstream stream(line);
        getline(stream, formulaStr, ';');
        getline(stream, assignmentStr, ';');

        // match basic format and reject all strings that dont match
        if (regex_match(formulaStr, regex("^[A-Za-z0-9*()+-]+$")))
        {
          // bool hasAssignment = (assignmentStr.empty() == false);

          if (assignmentStr.empty() || regex_match(assignmentStr, regex("^[A-Za-z0-9]{1,10}\\:(1|0|\\-1|\\-0)(,[A-Za-z0-9]{1,10}\\:(1|0|\\-1|\\-0))*$")))
          {
            // lets create a map and store assignments, if they exist
            bool contra_assgn = false;
            if (!assignmentStr.empty())
            {
              map<string, string> assMap;
              string individualAssignments;
              string key;
              string value;
              stringstream assStream(assignmentStr);
              while (!assStream.eof())
              {
                getline(assStream, individualAssignments, ',');
                stringstream indAssStream(individualAssignments);
                while (!indAssStream.eof())
                {
                  getline(indAssStream, key, ':');
                  getline(indAssStream, value, ':');
                  if (assMap.count(key) != 0 && assMap[key] != value)
                  {
                    contra_assgn = true;
                  }
                  else
                  {
                    formulaStr = regex_replace(formulaStr, regex(key), value);
                    assMap.insert(pair<string, string>(key, value));
                    for (auto i : assMap)
                    {
                      regex_replace(i.first, regex(key), value);
                    }
                  }
                }
              }
            }

            if (contra_assgn == false && checkBalance(formulaStr) != -1)
            {
              int output = process(formulaStr);
              if (output == -1)
              {
                cout << "Error:Invalid output from process" << endl;
              }
              else
              {
                cout << output << endl;
              }
            }
            else
            {
              cout << "Error:unbalanced params or contradicting assignment" << endl;
            }
          }
          else
          {
            cout << "Error:Assignmnet string Invalid" << endl;
          }
        }
        else
        {
          cout << "Error: formula string invalid" << endl;
        }
      }
      else
      {
        cout << "Error: Invalid string without ;" << endl;
      }
    }
    catch (exception e)
    {
      cout << "Error: Invalid String" << endl;
    }
  }
}
