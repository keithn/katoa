using System;
using System.Collections.Generic;

namespace Katoa
{
    public static class StringCsvExtensions
    {
        enum ParsingState
        {
            Value,
            InQuote,
        }

        public static List<string> Csv(this string values)
        {
            var result = new List<string>();
            var state = ParsingState.Value;
            var value = "";
            foreach (var c in values)
            {
                switch (state)
                {
                    case ParsingState.Value:
                        switch (c)
                        {
                            case '"':
                                state = ParsingState.InQuote;
                                break;
                            case ',':
                                state = ParsingState.Value;
                                result.Add(value);
                                value = "";
                                break;
                            default:
                                value += c;
                                break;
                        }
                        break;
                    case ParsingState.InQuote:
                        switch (c)
                        {
                            case '"':
                                state = ParsingState.Value;
                                break;
                            default:
                                value += c;
                                break;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            result.Add(value);
            return result;
        }
    }
}