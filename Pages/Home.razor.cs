using Microsoft.AspNetCore.Components.Web;
using System.Text;

namespace TranspositionCipher.Pages;

public partial class Home
{
    private int _key = 0;

    private string _originalText = string.Empty;
    private string _resultCipherText = string.Empty;

    private string _cipherText= string.Empty;
    private string _resultDecipherText = string.Empty;

    private Task CipherTransposition()
    {
        if (_key <= 0 || string.IsNullOrEmpty(_originalText)) return Task.CompletedTask;

        StringBuilder cipherText = new();
        int length = _originalText.Length;
        int numRows = (int)Math.Ceiling((double)length / _key);

        for (int col = 0; col < _key; col++)
            for (int row = col; row < length; row += _key)
                cipherText.Append(_originalText[row]);

        _resultCipherText = cipherText.ToString();
        return Task.CompletedTask;
    }

    private Task DecipherTransposition()
    {
        if (_key <= 0 || string.IsNullOrEmpty(_cipherText)) return Task.CompletedTask;

        int length = _cipherText.Length;
        int numRows = (int)Math.Ceiling((double)length / _key);
        char[] result = new char[length];

        int index = 0;
        for (int col = 0; col < _key; col++)
            for (int row = col; row < length; row += _key)
                if (index < length)
                    result[row] = _cipherText[index++];

        _resultDecipherText = new string(result);
        return Task.CompletedTask;
    }
}
