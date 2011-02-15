Imports FileReplacement

Module Module1

    Sub Main()

        FileRepository.AddPhysicalFallbacks("c:\test\sub",
                                            "c:\else")


        If IO.File.Exists("c:\test\sub\test.txt") Then
            IO.File.Delete("c:\test\sub\test.txt")
        End If

        If IO.File.Exists("c:\else\test.txt") Then
            IO.File.Delete("c:\else\test.txt")
        End If

        IO.Directory.CreateDirectory("C:\else")

        'void type
        Dim file = FileRepository.GetFileFromDisk("c:\test\sub\test.txt")
        Console.WriteLine("{0} : {1}", CStr(file.Type), IO.Path.Combine(file.Directory, file.Name))




        Using sw = New IO.StreamWriter("c:\else\test.txt")
            sw.WriteLine("omg!")
        End Using

        'physical, from backup location
        file = FileRepository.GetFileFromDisk("c:\test\sub\test.txt")
        Console.WriteLine("{0} : {1}", CStr(file.Type), IO.Path.Combine(file.Directory, file.Name))



        IO.Directory.CreateDirectory("c:\test\sub\")
        Using sw = New IO.StreamWriter("c:\test\sub\test.txt")
            sw.WriteLine("omg! again!")
        End Using

        'physical, from correct location
        file = FileRepository.GetFileFromDisk("c:\test\sub\test.txt")
        Console.WriteLine("{0} : {1}", CStr(file.Type), IO.Path.Combine(file.Directory, file.Name))

        Console.ReadKey()

    End Sub

End Module
