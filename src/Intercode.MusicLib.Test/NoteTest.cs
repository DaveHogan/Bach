﻿// 
//   NoteTest.cs: 
// 
//   Author: Eddie Velasquez
// 
//   Copyright (c) 2013  Intercode Consulting, LLC.  All Rights Reserved.
// 
//      Unauthorized use, duplication or distribution of this software, 
//      or any portion of it, is prohibited.  
// 
//   http://www.intercodeconsulting.com
// 

namespace Intercode.MusicLib.Test
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   /// <summary>
   ///    This is a test class for NoteTest and is intended
   ///    to contain all NoteTest Unit Tests
   /// </summary>
   [ TestClass ]
   public class NoteTest
   {
      #region Properties

      /// <summary>
      ///    Gets or sets the test context which provides
      ///    information about and functionality for the current test run.
      /// </summary>
      public TestContext TestContext { get; set; }

      #endregion

      /// <summary>
      ///    A test for Note Constructor
      /// </summary>
      [ TestMethod ]
      public void NoteConstructorTest()
      {
         var target = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.AreEqual(target.Tone, Tone.A);
         Assert.AreEqual(target.Accidental, Accidental.Natural);
         Assert.AreEqual(target.Octave, 1);
      }

      [ TestMethod ]
      public void EqualsContractTest()
      {
         object x = Note.Create(Tone.A, Accidental.Natural, 1);
         object y = Note.Create(Tone.A, Accidental.Natural, 1);
         object z = Note.Create(Tone.A, Accidental.Natural, 1);

         Assert.IsTrue(x.Equals(x)); // Reflexive
         Assert.IsTrue(x.Equals(y)); // Symetric
         Assert.IsTrue(y.Equals(x));
         Assert.IsTrue(y.Equals(z)); // Transitive
         Assert.IsTrue(x.Equals(z));
         Assert.IsFalse(x.Equals(null)); // Never equal to null
      }

      [ TestMethod ]
      public void TypeSafeEqualsContractTest()
      {
         var x = Note.Create(Tone.A, Accidental.Natural, 1);
         var y = Note.Create(Tone.A, Accidental.Natural, 1);
         var z = Note.Create(Tone.A, Accidental.Natural, 1);

         Assert.IsTrue(x.Equals(x)); // Reflexive
         Assert.IsTrue(x.Equals(y)); // Symetric
         Assert.IsTrue(y.Equals(x));
         Assert.IsTrue(y.Equals(z)); // Transitive
         Assert.IsTrue(x.Equals(z));
         Assert.IsFalse(x.Equals(null)); // Never equal to null
      }

      [ TestMethod ]
      public void EqualsFailsWithDifferentTypeTest()
      {
         object actual = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.IsFalse(actual.Equals(Int32.MinValue));
      }

      [ TestMethod ]
      public void TypeSafeEqualsFailsWithDifferentTypeTest()
      {
         var actual = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.IsFalse(actual.Equals(Int32.MinValue));
      }

      [ TestMethod ]
      public void EqualsFailsWithNullTest()
      {
         object actual = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.IsFalse(actual.Equals(null));
      }

      [ TestMethod ]
      public void TypeSafeEqualsFailsWithNullTest()
      {
         var actual = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.IsFalse(actual.Equals(null));
      }

      [ TestMethod ]
      public void EqualsSucceedsWithSameObjectTest()
      {
         var actual = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.IsTrue(actual.Equals(actual));
      }

      [ TestMethod ]
      public void GetHashcodeTest()
      {
         var actual = Note.Create(Tone.A, Accidental.Natural, 1);
         var expected = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.IsTrue(expected.Equals(actual));
         Assert.AreEqual(expected.GetHashCode(), actual.GetHashCode());
      }

      [ TestMethod ]
      public void CompareToContractTest()
      {
         {
            var a = Note.Create(Tone.A, Accidental.Natural, 1);
            Assert.IsTrue(a.CompareTo(null) > 0);
            Assert.IsTrue(a.CompareTo(a) == 0);

            var b = Note.Create(Tone.A, Accidental.Natural, 1);
            Assert.IsTrue(a.CompareTo(b) == 0);
            Assert.IsTrue(b.CompareTo(a) == 0);

            var c = Note.Create(Tone.A, Accidental.Natural, 1);
            Assert.IsTrue(b.CompareTo(c) == 0);
            Assert.IsTrue(a.CompareTo(c) == 0);
         }
         {
            var a = Note.Create(Tone.C, Accidental.Natural, 1);
            var b = Note.Create(Tone.D, Accidental.Natural, 1);

            Assert.AreEqual(a.CompareTo(b), -b.CompareTo(a));

            var c = Note.Create(Tone.E, Accidental.Natural, 1);
            Assert.IsTrue(a.CompareTo(b) < 0);
            Assert.IsTrue(b.CompareTo(c) < 0);
            Assert.IsTrue(a.CompareTo(c) < 0);
         }
      }

      [ TestMethod ]
      public void CompareToTest()
      {
         var a1 = Note.Create(Tone.A, Accidental.Natural, 1);
         var aSharp1 = Note.Create(Tone.A, Accidental.Sharp, 1);
         var aFlat1 = Note.Create(Tone.A, Accidental.Flat, 1);
         var a2 = Note.Create(Tone.A, Accidental.Natural, 2);
         var aSharp2 = Note.Create(Tone.A, Accidental.Sharp, 2);
         var aFlat2 = Note.Create(Tone.A, Accidental.Flat, 2);

         Assert.IsTrue(a1.CompareTo(a1) == 0);
         Assert.IsTrue(a1.CompareTo(aSharp1) < 0);
         Assert.IsTrue(a1.CompareTo(aFlat1) > 0);
         Assert.IsTrue(a1.CompareTo(a2) < 0);
         Assert.IsTrue(a1.CompareTo(aFlat2) < 0);
         Assert.IsTrue(a1.CompareTo(aSharp2) < 0);

         var c1 = Note.Create(Tone.C, Accidental.Natural, 1);
         Assert.IsTrue(a1.CompareTo(c1) > 0);
         Assert.IsTrue(c1.CompareTo(a1) < 0);
      }

      [ TestMethod ]
      public void ToStringTest()
      {
         var target = Note.Create(Tone.A, Accidental.DoubleFlat, 1);
         Assert.AreEqual("Abb1", target.ToString());

         target = Note.Create(Tone.A, Accidental.Flat, 1);
         Assert.AreEqual("Ab1", target.ToString());

         target = Note.Create(Tone.A, Accidental.Natural, 1);
         Assert.AreEqual("A1", target.ToString());

         target = Note.Create(Tone.A, Accidental.Sharp, 1);
         Assert.AreEqual("A#1", target.ToString());

         target = Note.Create(Tone.A, Accidental.DoubleSharp, 1);
         Assert.AreEqual("A##1", target.ToString());
      }

      [ TestMethod ]
      public void op_EqualityTest()
      {
         var a = Note.Create(Tone.A, Accidental.Natural, 1);
         var b = Note.Create(Tone.A, Accidental.Natural, 1);
         var c = Note.Create(Tone.B, Accidental.Natural, 1);

         Assert.IsTrue(a == b);
         Assert.IsFalse(a == c);
         Assert.IsFalse(b == c);
      }

      [ TestMethod ]
      public void op_InequalityTest()
      {
         var a = Note.Create(Tone.A, Accidental.Natural, 1);
         var b = Note.Create(Tone.A, Accidental.Natural, 1);
         var c = Note.Create(Tone.B, Accidental.Natural, 1);

         Assert.IsTrue(a != c);
         Assert.IsTrue(b != c);
         Assert.IsFalse(a != b);
      }

      [ TestMethod ]
      public void ComparisonOperatorsTest()
      {
         var a = Note.Create(Tone.A, Accidental.Natural, 1);
         var b = Note.Create(Tone.B, Accidental.Natural, 1);

         Assert.IsTrue(b > a);
         Assert.IsTrue(b >= a);
         Assert.IsFalse(b < a);
         Assert.IsFalse(b <= a);
      }

      [ TestMethod ]
      [ ExpectedException(typeof( ArgumentException )) ]
      public void C1DoubleFlatThrowsTest()
      {
         Note.Create(Tone.C, Accidental.DoubleFlat, 0);
      }

      [ TestMethod ]
      [ ExpectedException(typeof( ArgumentException )) ]
      public void C1FlatThrowsTest()
      {
         Note.Create(Tone.C, Accidental.Flat, 0);
      }

      [ TestMethod ]
      [ ExpectedException(typeof( ArgumentException )) ]
      public void B8SharpThrowsTest()
      {
         Note.Create(Tone.B, Accidental.Sharp, 9);
      }

      [ TestMethod ]
      [ ExpectedException(typeof( ArgumentException )) ]
      public void B8DoubleSharpThrowsTest()
      {
         Note.Create(Tone.B, Accidental.DoubleSharp, 9);
      }

      [ TestMethod ]
      public void AbsoluteValueTest()
      {
         Assert.AreEqual(0, Note.Parse("C0").AbsoluteValue);
         Assert.AreEqual(1, Note.Parse("C#0").AbsoluteValue);
         Assert.AreEqual(2, Note.Parse("C##0").AbsoluteValue);
         Assert.AreEqual(11, Note.Parse("B0").AbsoluteValue);
         Assert.AreEqual(12, Note.Parse("C1").AbsoluteValue);
         Assert.AreEqual(Note.Parse("Db1").AbsoluteValue, Note.Parse("C#1").AbsoluteValue);
         Assert.AreEqual(Note.Parse("C2").AbsoluteValue, Note.Parse("B#1").AbsoluteValue);
      }

      [ TestMethod ]
      public void op_SubtractionNoteTest()
      {
         var cDoubleFlat2 = Note.Create(Tone.C, Accidental.DoubleFlat, 2);
         var cFlat2 = Note.Create(Tone.C, Accidental.Flat, 2);
         var c2 = Note.Create(Tone.C, Accidental.Natural, 2);
         var cSharp2 = Note.Create(Tone.C, Accidental.Sharp, 2);
         var cDoubleSharp2 = Note.Create(Tone.C, Accidental.DoubleSharp, 2);

         // Test interval with same notes in the same octave with different accidentals
         Assert.AreEqual(cDoubleFlat2 - cDoubleFlat2, 0);
         Assert.AreEqual(cDoubleFlat2 - cFlat2, 1);
         Assert.AreEqual(cDoubleFlat2 - c2, 2);
         Assert.AreEqual(cDoubleFlat2 - cSharp2, 3);
         Assert.AreEqual(cDoubleFlat2 - cDoubleSharp2, 4);
         Assert.AreEqual(cFlat2 - cDoubleFlat2, -1);
         Assert.AreEqual(c2 - cDoubleFlat2, -2);
         Assert.AreEqual(cSharp2 - cDoubleFlat2, -3);
         Assert.AreEqual(cDoubleSharp2 - cDoubleFlat2, -4);

         var c3 = Note.Create(Tone.C, Accidental.Natural, 3);
         Assert.AreEqual(c2 - c3, 12);
         Assert.AreEqual(c3 - c2, -12);
      }

      [ TestMethod ]
      public void op_AdditionIntTest()
      {
         var c2 = Note.Create (Tone.C, Accidental.Natural, 2);
            
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Sharp, 2), c2 + 1);
         Assert.AreEqual(Note.Create(Tone.B, Accidental.Natural, 1), c2 + -1);
         Assert.AreEqual(Note.Create(Tone.D, Accidental.Natural, 2), c2 + 2);
         Assert.AreEqual(Note.Create(Tone.A, Accidental.Sharp, 1), c2 + -2);

      }

      [ TestMethod ]
      public void op_IncrementTest()
      {
         var c2 = Note.Create (Tone.C, Accidental.Natural, 2);
            
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Sharp, 2), ++c2);
         Assert.AreEqual(Note.Create(Tone.D, Accidental.Natural, 2), ++c2);
      }

      [ TestMethod ]
      public void op_SubtractionIntTest()
      {
         var c2 = Note.Create(Tone.C, Accidental.Natural, 2);

         Assert.AreEqual(Note.Create(Tone.B, Accidental.Natural, 1), c2 - 1);
         Assert.AreEqual(Note.Create(Tone.A, Accidental.Sharp, 1), c2 - 2);
      }

      [ TestMethod ]
      public void op_DecrementTest()
      {
         var c2 = Note.Create(Tone.C, Accidental.Natural, 2);

         Assert.AreEqual(Note.Create(Tone.B, Accidental.Natural, 1), --c2);
         Assert.AreEqual(Note.Create(Tone.A, Accidental.Sharp, 1), --c2);
      }

      [ TestMethod ]
      public void op_AdditionIntAccidentalModeTest()
      {
         var c2 = Note.Create(Tone.C, Accidental.Natural, 2);

         Note.AccidentalMode = AccidentalMode.FavorSharps;

         Note actual = c2 + 1;
         Assert.AreEqual("C#2", actual.ToString());

         Note.AccidentalMode = AccidentalMode.FavorFlats;

         actual = c2 + 1;
         Assert.AreEqual("Db2", actual.ToString());
      }

      [ TestMethod ]
      public void op_SubtractionIntAccidentalModeTest()
      {
         var c2 = Note.Create(Tone.C, Accidental.Natural, 2);

         Note.AccidentalMode = AccidentalMode.FavorSharps;

         Note actual = c2 - 2;
         Assert.AreEqual("A#1", actual.ToString());

         Note.AccidentalMode = AccidentalMode.FavorFlats;

         actual = c2 - 2;
         Assert.AreEqual("Bb1", actual.ToString());
      }

      [ TestMethod ]
      public void TryParseTest()
      {
         Note actual;
         Assert.IsTrue(Note.TryParse("C", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Natural, 4), actual);

         Assert.IsTrue(Note.TryParse("C#", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Sharp, 4), actual);

         Assert.IsTrue(Note.TryParse("C##", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.DoubleSharp, 4), actual);

         Assert.IsTrue(Note.TryParse("Cb", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Flat, 4), actual);

         Assert.IsTrue(Note.TryParse("Cbb", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.DoubleFlat, 4), actual);

         Assert.IsTrue(Note.TryParse("C2", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Natural, 2), actual);

         Assert.IsTrue(Note.TryParse("C#2", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Sharp, 2), actual);

         Assert.IsTrue(Note.TryParse("C##2", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.DoubleSharp, 2), actual);

         Assert.IsTrue(Note.TryParse("Cb2", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.Flat, 2), actual);

         Assert.IsTrue(Note.TryParse("Cbb2", out actual));
         Assert.AreEqual(Note.Create(Tone.C, Accidental.DoubleFlat, 2), actual);

         Assert.IsFalse(Note.TryParse("H", out actual));
         Assert.IsNull(actual);

         Assert.IsFalse(Note.TryParse("C!", out actual));
         Assert.IsNull(actual);

         Assert.IsFalse(Note.TryParse("C#-1", out actual));
         Assert.IsNull(actual);

         Assert.IsFalse(Note.TryParse("C#10", out actual));
         Assert.IsNull(actual);

         Assert.IsFalse(Note.TryParse("C#b2", out actual));
         Assert.IsNull(actual);

         Assert.IsFalse(Note.TryParse("Cb#2", out actual));
         Assert.IsNull(actual);
      }

      [ TestMethod ]
      public void FrequencyTest()
      {
         Assert.AreEqual(440.0, Math.Round(Note.Parse("A4").Frequency, 2));
         Assert.AreEqual(523.25, Math.Round(Note.Parse("C5").Frequency, 2));
         Assert.AreEqual(349.23, Math.Round(Note.Parse("F4").Frequency, 2));
         Assert.AreEqual(880.0, Math.Round(Note.Parse("A5").Frequency, 2));
      }

   }
}
