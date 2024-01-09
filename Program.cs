using BasicCsharp;
using System.Drawing;

var colors = GetColorsFromText(imageText.Image);

Downsample(colors, 4);

// This is the algorithm
Bitmap Downsample(Color[,] colors, int factor)
{
    var width = (int)Math.Ceiling((float)colors.GetLength(0) / factor);
    var height = (int)Math.Ceiling((float)colors.GetLength(1) / factor);
    Bitmap output = new Bitmap(width, height);

    for (int i = 1; i < colors.GetLength(0) - 1; i += factor)
    {
        for (int j = 1; j < colors.GetLength(1) - 1; j += factor)
        {
            int r = 0, g = 0, b = 0;
            Color[] c = new Color[9];
            c[0] = colors[i, j + 1];
            c[1] = colors[i, j];
            c[2] = colors[i, j - 1];
            c[3] = colors[i + 1, j + 1];
            c[4] = colors[i + 1, j];
            c[5] = colors[i + 1, j - 1];
            c[6] = colors[i - 1, j + 1];
            c[7] = colors[i - 1, j];
            c[8] = colors[i - 1, j - 1];

            var color = Average(c);
            output.SetPixel(i / factor, j / factor, color);
        }
    }
    var savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    output.Save(savePath + @$"/cartman_{factor}.jpeg");
    return output;
}

Bitmap Reconstruct(Color[,] colors)
{
    var width = colors.GetLength(0);
    var height = colors.GetLength(1);
    Bitmap output = new Bitmap(width, height);

    for (int i = 0; i < width; i++)
    {
        for (int j = 0; j < height; j++)
        {
            output.SetPixel(i, j, colors[i, j]);
        }
    }

    var savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    output.Save(savePath + @"/cartman.jpeg");
    return output;
}

Color Average(params Color[] colors)
{
    int r = 0, g = 0, b = 0;
    foreach (var item in colors)
    {
        r += item.R;
        g += item.G;
        b += item.B;
    }
    var sum = colors.Length;

    var r1 = (int)((float)r / sum);
    var g1 = (int)((float)g / sum);
    var b1 = (int)((float)b / sum);
    return Color.FromArgb(r1, g1, b1);
}

Color[,] GetColorsFromText(string path)
{
    var txt = File.ReadAllLines(path);
    var header = txt[0];
    var w = GetValue(header, "Width");
    var h = GetValue(header, "Height");
    var colors = new Color[w, h];
    var conv = new ColorConverter();

    for (int i = 0; i < w; i++)
    {
        for (int j = 0; j < h; j++)
        {
            Color color;
            var index = i * (h - 1) + j;
            if (index == 0)
            {
                index++;
            }
            color = (Color)conv.ConvertFromString("#" + txt[index]);
            colors[i, j] = color;
        }
    }
    return colors;
}

int GetValue(string line, string tag)
{
    var start = line.IndexOf(tag + "=") + tag.Length + 1;
    var end = start;
    for (int i = start; i < line.Length; i++)
    {
        if (!char.IsDigit(line[i]))
        {
            end = i;
            break;
        }
    }

    return int.Parse(line.Substring(start, end - start));
}