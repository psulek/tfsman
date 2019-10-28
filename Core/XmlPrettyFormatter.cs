using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TFSManager.Core
{
    public class XmlPrettyFormatter
    {
        private const string PRETTY_XML_SHEET =
            "<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"><xsl:output method=\"xml\" omit-xml-declaration=\"yes\"/><xsl:param name=\"indent-increment\" select=\"'   '\" /><xsl:template match=\"*\"><xsl:param name=\"indent\" select=\"'&#xA;'\"/><xsl:value-of select=\"$indent\"/><xsl:copy><xsl:copy-of select=\"@*\" /><xsl:apply-templates><xsl:with-param name=\"indent\" select=\"concat($indent, $indent-increment)\"/></xsl:apply-templates><xsl:if test=\"*\"><xsl:value-of select=\"$indent\"/></xsl:if></xsl:copy></xsl:template><xsl:template match=\"comment()|processing-instruction()\"><xsl:copy /></xsl:template><xsl:template match=\"text()[normalize-space(.)='']\"/></xsl:stylesheet>";


        private class TextStringReader : StringReader
        {
            public TextStringReader(string buffer)
                : base(buffer)
            { }

            public override string ReadToEnd()
            {
                StringBuilder sb = new StringBuilder();
                string line = ReadLine();
                if (line != null)
                {
                    sb.Append(line);
                }
                while ((line = ReadLine()) != null)
                {
                    sb.Append('\n');
                    sb.Append(line);
                }

                Close();
                return sb.ToString();
            }
        }

        private static string TransformXml(string xml, string xslData, string cssData)
        {
            if (xml == null || xml.Length == 0)
            {
                return xml;
            }
            string html = null;
            StringReader stringReader = new StringReader(xml);
            StringReader streamReader = null;
            StringWriter stringWriter = null;
            XmlTextReader xmlReader = null;
            try
            {
                XPathDocument xpathDocument = new XPathDocument(stringReader);
                XslCompiledTransform xslTransform = new XslCompiledTransform();

                streamReader = new TextStringReader(xslData);
                xmlReader = new XmlTextReader(streamReader);
                xslTransform.Load(xmlReader);

                XsltArgumentList args = new XsltArgumentList();

                if (cssData != null)
                {
                    args.AddParam("cssdata", string.Empty, cssData);
                }

                XPathNavigator xpathNavigator = xpathDocument.CreateNavigator();
                stringWriter = new StringWriter();

                xslTransform.Transform(xpathNavigator, args, stringWriter);
                html = stringWriter.ToString().Trim();
            }
            catch
            {
                return xml;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                stringReader.Close();
                if (stringWriter != null)
                {
                    stringWriter.Close();
                }
            }

            return html;
        }

        public static string Format(string xml)
        {
            return Format(xml, 2, ' ');
        }

        public static string Format(string xml, int indentSize, char indentChar)
        {
            string result = TransformXml(xml, PRETTY_XML_SHEET, null);
            return result;
        }
    }
}