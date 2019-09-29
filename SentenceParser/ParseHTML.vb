Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO
Imports OpenNLP.Tools.SentenceDetect
Imports System.Collections.Generic
Imports OpenNLP.Tools.Tokenize
Imports System.Collections.Specialized
Imports System.Configuration


Public Class ParseHTML

    Private Sub btnParseHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParseHtml.Click
        Dim webPage As String = DownloadWebPage(txtURL.Text)
        'Minimum word number threshold to trigger a sentence.
        Dim MinimumNumberOfWordsInSentence As Integer = 3

        ' these functions clean the html out of the page and just leave us with the text content
        Dim webPageStripped As String = StripHTML(webPage)
        ' Replace non breaking spaces with a regular space
        webPageStripped = webPageStripped.Replace("&nbsp;", " ")
        ' Replace multiple spaces with 1 space
        webPageStripped = Regex.Replace(webPageStripped, "\s+", " ")
        ' Strip any blank lines
        webPageStripped = StripBlankLines(webPageStripped)
        ' Strip Any Hex Codes
        webPageStripped = StripHexCodes(webPageStripped)

        ' Fire up the Sentence Detector
        ' You need to set the path to the Model folder specific to your machine
        Dim sentenceDetector As EnglishMaximumEntropySentenceDetector =
        New EnglishMaximumEntropySentenceDetector(My.Settings.ModelDirectory & "EnglishSD.nbin")
        Dim sentences As String() = sentenceDetector.SentenceDetect(webPageStripped)
        Dim sentenceList As List(Of StringValue) = New List(Of StringValue)

        For Each sentence As String In sentences
            'If Regex.IsMatch(sentence, "((?<=[a-z0-9)][.?!])|(?<=[a-z0-9][.?!]\""))(\s|\r\n)(?=\""?[A-Z])") Then

            ' Assume a sentence has more than 2 words
            If sentence.Split(" ").Length > MinimumNumberOfWordsInSentence Then
                ' The following regular expressions remove unwanted numerals such as a) and 1., etc from the beginning of sentences
                sentence = Regex.Replace(sentence, "^\d*[-._\s]*", "")
                sentence = Regex.Replace(sentence, "^\d*[-._\s]*", "") ' This is not a mistake it needs to be here twice
                sentence = Regex.Replace(sentence, "^[a-zA-Z]\)", "")
                sentence = Regex.Replace(sentence, "^\([a-zA-Z]\)", "")
                sentence = Regex.Replace(sentence, "^\([0-9]\)", "")
                sentence = Regex.Replace(sentence, "^[a-zA-Z][.]", "")
                sentence = sentence.Trim(" ")
                sentence = sentence.TrimStart("[]")
                If sentence.Split(" ").Length > MinimumNumberOfWordsInSentence And Regex.IsMatch(sentence, "^[A-Z]") Then
                    sentenceList.Add(New StringValue(sentence))
                End If

            End If

        Next

        grdViewSentences.DataSource = sentenceList

    End Sub

    Public Shared Function DownloadWebPage(ByVal Url As String) As String
        ' Open a connection
        Dim Response As WebResponse
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)


        If Url.Contains("http") Then
            Dim WebRequestObject As HttpWebRequest = DirectCast(HttpWebRequest.Create(Url), HttpWebRequest)

            ' You can also specify additional header values like 
            ' the user agent or the referer:
            WebRequestObject.UserAgent = ".NET Framework/4.0"
            WebRequestObject.Referer = "http://www.example.com/"
            WebRequestObject.UseDefaultCredentials = True

            ' Request response:
            Response = WebRequestObject.GetResponse()
        Else

            Dim fileWebRequest As FileWebRequest = DirectCast(fileWebRequest.Create(Url), FileWebRequest)

            Response = fileWebRequest.GetResponse()

        End If



        ' Open data stream:
        Dim WebStream As Stream = Response.GetResponseStream()

        ' Create reader object:
        Dim Reader As New StreamReader(WebStream)

        ' Read the entire stream content:
        Dim PageContent As String = Reader.ReadToEnd()

        ' Cleanup
        Reader.Close()
        WebStream.Close()
        Response.Close()

        Return PageContent
    End Function

    Private Shared Function StripHTML(ByVal htmlString As String) As String

        'This pattern Matches everything found inside html tags;

        '(.|\n) - > Look for any character or a new line

        ' *?  -> 0 or more occurences, and make a non-greedy search meaning

        'That the match will stop at the first available '>' it sees, and not at the last one

        '(if it stopped at the last one we could have overlooked

        'nested HTML tags inside a bigger HTML tag..)

        ' Thanks to Oisin and Hugh Brown for helping on this one...

        Dim pattern As String = "<(.|\n)*?>"
        Return Regex.Replace(htmlString, pattern, String.Empty)

    End Function

    Public Shared Function StripBlankLines(ByVal htmlString As String) As String

        Dim pattern As String = "^\r?\n?$"
        Return Regex.Replace(htmlString, pattern, String.Empty)

    End Function

    Public Shared Function StripHexCodes(ByVal htmlString As String) As String

        Dim pattern As String = "&#\d{3,4};"
        Return Regex.Replace(htmlString, pattern, String.Empty)

    End Function

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            txtURL.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class

Public Class StringValue
    Public Sub New(ByVal s As String)
        Value = s
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property
    Private _value As String
End Class