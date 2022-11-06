using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Threading;
using System;
using System.Threading.Tasks;

public class TestSuite : InputTestFixture
{
    public string TestCellName = "DevCell";
    private GameObject PlayerRef;
    public GameObject PlayerPrefab = Resources.Load("Player", typeof(GameObject)) as GameObject;
    private PlayerController PrimaryController;
    private GameObject SkeletonRef;
    public GameObject SkeletonPrefab = Resources.Load("Skeleton") as GameObject;
    private Input CurInput;
    private Keyboard KeyboardRef;
    private Mouse MouseRef;
    private PlayerController PCRef;
    private HealthManager PCHP;
    private TestReferenceLedger TestRefs;
    private int TestsCompleted;

    private static readonly int TestingTestID = 1;
    private static readonly int LoadStartScreenTestID = 2;
    private static readonly int StartMenuTestID = 3;
    private static readonly int NewGameTestID = 4;
    private static readonly int PlayerVerifyTestID = 5;
    private static readonly int CellPathTestID = 6;
    private static readonly int LoadTestCellID = 7;
    private static readonly int HorizontalMovementTestID = 8;
    private static readonly int JumpTestID = 9;
    private static readonly int DashTestID = 10;
    private static readonly int CombatTestID = 11;
    private static readonly int CameraLimitTestID = 12;
    private static readonly int PlatformEffectorTestID = 13;
    private static readonly int HPBarTestID = 14;
    private static readonly int PauseMenuTestID = 15;
    private static readonly int SaveGameTestID = 16;
    private static readonly int PauseTitleTestID = 17;
    private static readonly int LoadGameTestID = 18;

    public void GetTestRefs() => TestRefs = GameObject.FindGameObjectWithTag("TestData").GetComponent<TestReferenceLedger>();




    /*[OneTimeSetUp]
    public void OneTimeSetUp()
    {
        //KeyboardRef = InputSystem.AddDevice<Keyboard>();
        //MouseRef = InputSystem.AddDevice<Mouse>();
        //EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/DevCell.unity", new LoadSceneParameters(LoadSceneMode.Single));
    }*/

    [Test, Order(1)]
    public void TestingTest()
    {
        Assert.IsTrue(true);
        TestsCompleted = TestingTestID;
    }


    /*[UnityTest, Order(2)]
    public IEnumerator SpawnPlayer()
    {
        PlayerRef = GameObject.Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        Assert.NotNull(PlayerRef);
        yield return null;
    }

    [UnityTest, Order(3)]
    public IEnumerator GetPlayer()
    {
        GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
        if (PCs.Length != 0)
        {
            Assert.AreEqual(PlayerRef, PCs[0]);
        }
        else
        {
            Assert.Fail();
        }
        yield return null;
    }*/

    [UnityTest, Order(2)]
    public IEnumerator LoadStartScreenTest()
    {
        while (TestsCompleted != (LoadStartScreenTestID - 1)) { yield return null; }
        //string curScene = SceneManager.GetActiveScene().name;
        EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/TitleMenu.unity", new LoadSceneParameters(LoadSceneMode.Single));
        yield return new WaitForSeconds(3f);
        //while (curScene == SceneManager.GetActiveScene().name) { yield return null; }
        Assert.AreEqual(SceneManager.GetActiveScene().name, "TitleMenu");
        TestsCompleted = LoadStartScreenTestID;
        yield return null;
    }


    [UnityTest, Order(3)]
    public IEnumerator StartMenuTest()
    {
        while (TestsCompleted != (StartMenuTestID - 1)) { yield return null; }
        //Task.WaitAll(TestingTest());
        //StartCoroutine(DelayAction(delayTime));
        yield return new WaitForSeconds(3f);
        GetTestRefs();
        GameObject StartButton = TestRefs.StartButton;
        Assert.True(StartButton.gameObject.activeSelf);
        yield return new WaitForSeconds(1f);
        StartButton.GetComponent<Button>().onClick.Invoke();
        Assert.False(StartButton.gameObject.activeSelf);
        TestsCompleted = StartMenuTestID;
        yield return null;
    }

    [UnityTest, Order(4)]
    public IEnumerator NewGameTest()
    {
        while (TestsCompleted != NewGameTestID - 1) { yield return null; }
        GameObject NGButton = TestRefs.NewGameButton;
        //string curScene = SceneManager.GetActiveScene().name;
        
        NGButton.GetComponent<Button>().onClick.Invoke();
        while (SceneManager.GetActiveScene().name != "FortCell2") { yield return null; }
        //yield return new WaitForSeconds(3f);
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenuController>().HowToPlayClose();
        yield return new WaitForSeconds(3f);
        //while (curScene == SceneManager.GetActiveScene().name) { yield return null; }
        //Assert.AreEqual(SceneManager.GetActiveScene().name, "FortCell2");
         TestsCompleted = NewGameTestID;
        Assert.Pass();
        yield return null;
    }

    [UnityTest, Order(5)]
    public IEnumerator PlayerVerifyTest()
    {
        while (TestsCompleted != PlayerVerifyTestID - 1) { yield return null; }
        GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
        if (PCs.Length != 0)
        {
            PlayerRef = PCs[0];
            PCRef = PlayerRef.GetComponent<PlayerController>();
            PCHP = PlayerRef.GetComponent<HealthManager>();
            Assert.NotNull(PlayerRef);
        }
        else
        {
            Assert.Fail();
        }
        TestsCompleted = PlayerVerifyTestID;
        yield return null;
    }

    [UnityTest, Order(6)]
    public IEnumerator CellPathTest()
    {

        while (TestsCompleted != CellPathTestID - 1) { yield return null; }
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        PCRef.thistf.position = new Vector3(-16, -2, 0);//.position.Set(-16, -2, 0);
        //PlayerRef.GetComponent<Transform>().position.Set(-16, -2, 0);
        //thistf.position = new Vector3(0, 0, 0);
        //Task.Run(async () => { await MoveLeft(20); }).Wait();
        //yield return new WaitForSeconds(0.100f);
        yield return new WaitForSeconds(3f);
        //string curScene = SceneManager.GetActiveScene().name;
        Assert.AreEqual(SceneManager.GetActiveScene().name, "FortCell1");
        //while (curScene == SceneManager.GetActiveScene().name) { yield return null; }
        TestsCompleted = CellPathTestID;
        yield return null;
    }

    [UnityTest, Order(7)]
    public IEnumerator LoadTestCell()
    {
        while (TestsCompleted != LoadTestCellID - 1) { yield return null; }
        //string curScene = SceneManager.GetActiveScene().name;
        EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/DevCell.unity", new LoadSceneParameters(LoadSceneMode.Single));
        yield return new WaitForSeconds(3f);
        //while (curScene == SceneManager.GetActiveScene().name) { yield return null; }
        Assert.AreEqual(SceneManager.GetActiveScene().name, "DevCell");
        TestsCompleted = LoadTestCellID;
        yield return null;
    }

    [UnityTest, Order(8)]
    public IEnumerator HorizontalMovementTest()
    {
        while (TestsCompleted != HorizontalMovementTestID - 1) { yield return null; }
        Vector3 pos1 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = "MoveRight";
        yield return new WaitForSeconds(1f);
        Vector3 pos2 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = "MoveLeft";
        yield return new WaitForSeconds(2f);
        Vector3 pos3 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = null;
        bool posCheck = false;
        if (pos1 != pos2 || pos1 != pos3 || pos2 != pos3)
        {
            posCheck = true;
        }
        Assert.IsTrue(posCheck);
        TestsCompleted = HorizontalMovementTestID;
        yield return null;
    }

    [UnityTest, Order(9)]
    public IEnumerator JumpTest()
    {
        while (TestsCompleted != JumpTestID - 1) { yield return null; }
        PCRef.DJUnlocked = true;
        PCRef.WJUnlocked = true;
        Vector3 pos1 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = "Jump";
        yield return new WaitForSeconds(1f);
        Vector3 pos2 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = null;
        yield return new WaitForSeconds(3f);
        Assert.AreNotEqual(pos1, pos2);
        TestsCompleted = JumpTestID;
        yield return null;
    }

    [UnityTest, Order(10)]
    public IEnumerator DashTest()
    {
        while (TestsCompleted != DashTestID - 1) { yield return null; }
        PCRef.DashUnlocked = true;
        PCRef.DebugCommand = "MoveRight";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Jump";
        Vector3 pos1 = PCRef.thistf.localPosition;
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Dash";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Null";
        yield return new WaitForSeconds(1f);
        Vector3 pos2 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = "MoveLeft";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Jump";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Dash";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Null";
        yield return new WaitForSeconds(1f);
        Assert.AreNotEqual(pos1, pos2);
        TestsCompleted = DashTestID;
        yield return null;
    }

    [UnityTest, Order(11)]
    public IEnumerator CombatTest()
    {
        while (TestsCompleted != CombatTestID - 1) { yield return null; }
        PCRef.thistf.position = new Vector3(24, 3, 0); //PlayerRef.transform.position.Set(24, 3, 0);
        PCRef.DebugCommand = "MoveRight";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Fire";
        yield return new WaitForSeconds(3f);
        PCRef.DebugCommand = null;
        PCRef.thistf.position = new Vector3(40, 3, 0);
        PCRef.DebugCommand = "MoveLeft";
        yield return new WaitForSeconds(0.1f);
        PCRef.DebugCommand = "Fire";
        yield return new WaitForSeconds(3f);
        PCRef.DebugCommand = null;
        GameObject[] BulletRefs = GameObject.FindGameObjectsWithTag("Projectile");
        Assert.NotZero(BulletRefs.Length); 
        TestsCompleted = CombatTestID;
        yield return null;
    }

    [UnityTest, Order(12)]
    public IEnumerator CameraLimitTest()
    {

        while (TestsCompleted != CameraLimitTestID - 1) { yield return null; }
        PCRef.thistf.position = new Vector3(55, 0, 0); //PlayerRef.transform.position.Set(55, 0, 0);
        Vector3 pos1 = PCRef.thistf.localPosition;
        yield return new WaitForSeconds(1f);
        PCRef.thistf.position = new Vector3(-55, 0, 0); ///PlayerRef.transform.position.Set(-55, 0, 0);
        Vector3 pos2 = PCRef.thistf.localPosition;
        yield return new WaitForSeconds(1f);
        PCRef.thistf.position = new Vector3(0, 55, 0); //PlayerRef.transform.position.Set(0, 55, 0);
        Vector3 pos3 = PCRef.thistf.localPosition;
        yield return new WaitForSeconds(1f);
        PCRef.thistf.position = new Vector3(0, -55, 0); //PlayerRef.transform.position.Set(0, -55, 0);
        Vector3 pos4 = PCRef.thistf.localPosition;
        yield return new WaitForSeconds(1f);
        bool TestCond = false;
        if (pos1 != pos2 && pos1 != pos3 && pos1 != pos4 && pos2 != pos3 && pos2 != pos4 && pos3 != pos4)
        {
            TestCond = true;
        }
        Assert.IsTrue(TestCond);
        TestsCompleted = CameraLimitTestID;
        yield return null;
    }

    [UnityTest, Order(13)]
    public IEnumerator PlatformEffectorTest()
    {
        while (TestsCompleted != PlatformEffectorTestID - 1) { yield return null; }
        PCRef.thistf.position = new Vector3(3, 22, 0);
        yield return new WaitForSeconds(3f);
        Vector3 pos1 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = "Crouch";
        yield return new WaitForSeconds(5f);
        Vector3 pos2 = PCRef.thistf.localPosition;
        PCRef.DebugCommand = null;
        Assert.AreNotEqual(pos1, pos2);
        TestsCompleted = PlatformEffectorTestID;
        yield return null;
    }

    [UnityTest, Order(14)]
    public IEnumerator HPBarTest()
    {
        while (TestsCompleted != HPBarTestID - 1) { yield return null; }
        int curHP = PCHP.currenthealth;
        PCHP.TakeDamage(1);
        yield return new WaitForSeconds(1f);
        float HPBarHP = GameObject.FindGameObjectWithTag("Canvas").GetComponent<HealthBarController>().thisSlider.value;
        Assert.AreNotEqual(curHP, (int)HPBarHP);
        TestsCompleted = HPBarTestID;
        yield return null;
    }
    [UnityTest, Order(15)]
    public IEnumerator PauseMenuTest()
    {
        while (TestsCompleted != PauseMenuTestID - 1) { yield return null; }
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenuController>().TogglePause();
        Assert.AreEqual(Time.timeScale, 0f);
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenuController>().TogglePause();
        TestsCompleted = PauseMenuTestID;
        yield return null;
    }

    [UnityTest, Order(16)]
    public IEnumerator SaveGameTest()
    {
        while (TestsCompleted != SaveGameTestID - 1) { yield return null; }
        EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/FortCell5.unity", new LoadSceneParameters(LoadSceneMode.Single));
        yield return new WaitForSeconds(3f);
        PCRef.thistf.position = new Vector3(-6, 13, 0);
        yield return new WaitForSeconds(3f);
        GameObject.FindGameObjectWithTag("SavePoint").GetComponent<SaveManager>().SaveGame();
        TestsCompleted = SaveGameTestID;
        Assert.Pass(); //If save happens successfully, it won't error out and reach this point. 
        
        yield return null;
    }

    [UnityTest, Order(17)]
    public IEnumerator PauseTitleTest()
    {
        while (TestsCompleted != PauseTitleTestID - 1) { yield return null; }
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenuController>().TogglePause();
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenuController>().TitleButton();
        //if (Time.timeScale != 0) { Assert.Fail(); }
        yield return new WaitForSeconds(3f);
        bool SceneTestPassed = false;
        bool PlayerTestPassed = false;
        if (SceneManager.GetActiveScene().name == "TitleMenu"){
            SceneTestPassed = true;
        }
        GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
        if (PCs.Length == 0)
        {
            PlayerTestPassed = true;
        }
        TestsCompleted = PauseTitleTestID;
        if (SceneTestPassed && PlayerTestPassed)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
        yield return null;
    }

    [UnityTest, Order(18)]
    public IEnumerator LoadGameTest()
    {
        while (TestsCompleted != LoadGameTestID - 1) { yield return null; }
        string curSceneName = SceneManager.GetActiveScene().name;
        GetTestRefs();
        GameObject LGButton = TestRefs.LoadGameButton;
        LGButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(3f);
        //while (curScene == SceneManager.GetActiveScene().name) { yield return null; }
        Assert.AreNotEqual(curSceneName, SceneManager.GetActiveScene().name);
        TestsCompleted = LoadGameTestID;
        yield return null;
    }

}