using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using classes;
using NUnit.Framework;

namespace Tests
{
  
   [TestFixture]
    public class LogicTest
    {

       [SetUp]
       public void setUP(){
           
       }

       [Test]

       public void c_DeleteDoctorInDataBase()
       {
           Delete deleteClass = new Delete();
           doctor testObject = new doctor(201067881, "Doctor", "Test", "male", 30000.0,"0");

           Assert.IsTrue(deleteClass.delete(testObject));

       }

       [Test]
       public void c_DeletePatientInDataBase()
       {
           Delete deleteClass = new Delete();
           patient testObject = new patient(033386731, "Patient", "Test", "female", 201067881, new DateTime(1984, 10, 13),"0");
            
           Assert.IsTrue(deleteClass.delete(testObject));
          

       }

       [Test]
       public void c_DeleteVisitInDataBase()
       {
           Delete deleteClass = new Delete();
           visit testObject = new visit(0,new DateTime(1984, 10, 13), 033386731, 201067881, "this is a test visit");

           Assert.IsTrue(deleteClass.delete(testObject));

       }

       [Test]
       public void c_DeleteTreatmentInDataBase()
       {
           Delete deleteClass = new Delete();
           treatment testObject = new treatment(0,new DateTime(2013, 10, 13), new DateTime(2015, 10, 1), 201067881, "this is a test treatment", "test", 0);
           Assert.IsTrue(deleteClass.delete(testObject));


       }
  [Test]
  public void b_editDoctorInDataBase()
  {
      Edit editClass = new Edit();
      doctor testObject = new doctor(201067881,"Doctor","Test","male",30000.0,"0");

      Assert.IsTrue(editClass.editParam(testObject, "firstName", "editTest"));
     
  }

       [Test]
  public void b_editPatientInDataBase()
  {
      Edit editClass = new Edit();
    patient testObject = new patient(033386731, "Patient", "Test", "female", 201067881, new DateTime(1984, 10, 13),"0");
    Assert.IsTrue(editClass.editParam(testObject, "firstName", "editTest"));
     
  }


       [Test]
       public void b_editVisitInDataBase()
       {
           Edit editClass = new Edit();
           visit testObject = new visit(0,new DateTime(1984, 10, 13), 033386731, 201067881, "this is a test visit");
           Assert.IsTrue(editClass.editParam(testObject, "doctorNotes", "editTest1"));

       }

       [Test]
       public void b_editTreatmentInDataBase()
       {
           Edit editClass = new Edit();
           treatment testObject = new treatment(0,new DateTime(2013, 10, 13), new DateTime(2015, 10, 1), 201067881, "this is a test treatment", "test", 0);
           Assert.IsTrue(editClass.editParam(testObject, "prognosis", "editTest"));

       }

       [Test]



       public void a_insertNewDoctorToDataBase()
       {
           Add addClass = new Add();
           String error = "";
           doctor testObject = new doctor(201067881, "Doctor", "Test", "male", 30000.0,"0");

           if (!addClass.add(testObject, out error))
           {
               Assert.Fail(error);
           }

       }
       [Test]
       public void a_insertNewPatientToDataBase()
       {
           Add addClass = new Add();
           String error = "";
           patient testObject = new patient(033386731, "Patient", "Test", "female", 201067881, new DateTime(1984, 10, 13),"0");

           if (!addClass.add(testObject, out error))
           {
               Assert.Fail(error);
           }

       }
       [Test]
       public void a_insertNewVisitToDataBase()
       {
           Add addClass = new Add();
           String error = "";
           visit testObject = new visit(new DateTime(1984, 10, 13, 00, 00, 00), 033386731, 201067881, "this is a test visit");

           if (!addClass.add(testObject, out error))
           {
               Assert.Fail(error);
           }

       }

       [Test]
       public void insertNewTreatmentToDataBase()
       {
           Add addClass = new Add();
           String error = "";
           treatment testObject = new treatment(new DateTime(2013, 10, 13), new DateTime(2015, 10, 1), 201067881, "this is a test treatment", "test", 0);

           if (!addClass.add(testObject, out error))
           {
               Assert.Fail(error);
           }

       }
    }
}
