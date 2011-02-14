Imports FileReplacement

Module Module1

    Sub Main()

        FileRepository.AddPhysicalFallbacks("c:\test\sub",
                                            "c:\else")


        IO.Directory.CreateDirectory("C:\else")

        'void type
        Dim file = FileRepository.GetFileFromDisk("c:\test\sub\test.txt")
        Console.WriteLine(file.Type)




        Using sw = New IO.StreamWriter("c:\else\test.txt")
            sw.WriteLine("omg!")
        End Using

        'physical, from backup location
        file = FileRepository.GetFileFromDisk("c:\test\sub\test.txt")
        Console.WriteLine(file.Type)



        IO.Directory.CreateDirectory("c:\test\sub\")
        Using sw = New IO.StreamWriter("c:\test\sub\test.txt")
            sw.WriteLine("omg! again!")
        End Using

        'physical, from correct location
        file = FileRepository.GetFileFromDisk("c:\test\sub\test.txt")
        Console.WriteLine(file.Type)

        Console.ReadKey()

    End Sub

End Module
