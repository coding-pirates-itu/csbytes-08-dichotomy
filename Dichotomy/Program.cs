var func = (double x) => x * x - 7 * x + 10;

const double Epsilon = 0.0001;
const double Limit = 1000;

// Find + and - points
var xl = -1.0;
var xr = 1.0;

var fl = func(xl);
var fr = func(xr);

while (xl > -Limit && xr < Limit && Math.Sign(fl) * Math.Sign(fr) != -1)
{
    if (Math.Abs(fl - fr) < Epsilon)
    {
        xl *= 2;
        xr *= 2;
        fl = func(xl);
        fr = func(xr);
    }
    else if (Math.Abs(fl) < Math.Abs(fr))
    {
        xl -= xr - xl;
        fl = func(xl);
    }
    else
    {
        xr += xr - xl;
        fr = func(xr);
    }
}

if (xl <= -Limit || xr >= Limit)
{
    Console.WriteLine("Cannot find pivot points. Exiting.");
    return;
}

Console.WriteLine($"Pivot points: ({xl}, {fl}), ({xr}, {fr})");

// Find the solution
var count = 0;
while (Math.Abs(fl - fr) > Epsilon)
{
    count++;
    //var mid = (xl + xr) / 2;
    //var fm = func(mid);
    var mid = xl + (xr - xl) / (Math.Abs(fl) + Math.Abs(fr)) * Math.Abs(fl);
    var fm = func(mid);

    if (Math.Abs(fm) < Epsilon)
    {
        xl = mid;
        fl = fm;
        break;
    }

    if (Math.Sign(fm) == Math.Sign(fl))
    {
        xl = mid;
        fl = fm;
    }
    else
    {
        xr = mid;
        fr = fm;
    }
}

Console.WriteLine($"Found solution: ({xl}, {fl}) in {count} iterations.");
