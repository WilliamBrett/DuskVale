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

    public void GetTestRefs() => TestRefs = GameObject.FindGameObjectWithTag("TestData").GetComponent<TestReferenceLedger>();

    public async Task TimeDelay(int frames)
    {
        for (int i = 0; i < frames; i++)
        {
            _ = EverythingUpdate();
        }
    }

    public async Task EverythingUpdate()
    {

        if (PlayerRef) await PlayerUpdate();
        await EnemyUpdate();
        await ProjectileUpdate();
    }

    public async Task PlayerUpdate()
    {
        PlayerRef.GetComponent<PlayerController>().Update();
        PlayerRef.GetComponent<HealthManager>().Update();
    }

    public async Task EnemyUpdate()
    {
        GameObject[] Hostiles = GameObject.FindGameObjectsWithTag("Hostile");
        if (Hostiles.Length != 0)
        {
            for (int i = 0; i < Hostiles.Length; i++)
            {
                if (Hostiles[i].GetComponent<SkeletonController>())
                {
                    Hostiles[i].GetComponent<SkeletonController>().Update();
                }
            }
        }
    }

    public async Task ProjectileUpdate()
    {
        GameObject[] Projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        if (Projectiles.Length != 0)
        {
            for (int i = 0; i < Projectiles.Length; i++)
            {
                Projectiles[i].GetComponent<ProjectileManager>().Update();
            }
        }
    }

    public async Task MoveRight(int frameCount)
    {
        for (int i = frameCount; i > 0; i++)
        {
            PCRef.HorizontalMove(1);
            await EverythingUpdate();
        }
    }

    public async Task MoveLeft(int frameCount)
    {
        for (int i = frameCount; i > 0; i++)
        {
            PCRef.HorizontalMove(-1);
            await EverythingUpdate();
        }
    }

    public async Task Dash()
    {
        PCRef.Dash();
        await TimeDelay(30);
    }

    public async Task Jump()
    {
        PCRef.Jump(1);
        await TimeDelay(15);
    }

    public async Task Fire()
    {
        if (PCRef.afterShotDelay == 0 && (PCRef.thisRB2D.velocity.x == 0 || PCRef.Crouching))
        {
            PCRef.FireBullet();
        }
        await EverythingUpdate();
    }


    /*public float FrameConversion(int FrameNum)
    {
        return ((float)0.02) * ((float)FrameNum);
    }*/




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
        Task.Run(async () => { await TimeDelay(200); }).Wait();
        GetTestRefs();
        GameObject StartButton = TestRefs.StartButton;
        Assert.True(StartButton.gameObject.activeSelf);
        Task.Run(async () => { await TimeDelay(15); ; }).Wait();
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
        yield return new WaitForSeconds(3f);
        //while (curScene == SceneManager.GetActiveScene().name) { yield return null; }
        Assert.AreEqual(SceneManager.GetActiveScene().name, "FortCell2");
        TestsCompleted = NewGameTestID;
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
        PCRef.thistf.position.Set(-16, -2, 0);
        PlayerRef.GetComponent<Transform>().position.Set(-16, -2, 0);
        Task.Run(async () => { await MoveLeft(20); }).Wait();
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
        Task.Run(async () => { await MoveRight(5); }).Wait();
        Task.Run(async () => { await MoveLeft(5); }).Wait();
        Assert.IsTrue(true);
        TestsCompleted = HorizontalMovementTestID;
        yield return null;
    }

    [UnityTest, Order(9)]
    public IEnumerator JumpTest()
    {
        while (TestsCompleted != JumpTestID - 1) { yield return null; }
        Task.Run(async () => { await Jump(); }).Wait();
        Task.Run(async () => { await Jump(); }).Wait();
        Task.Run(async () => { await Jump(); }).Wait();
        Task.Run(async () => { await TimeDelay(100); }).Wait();
        Assert.IsTrue(true);
        TestsCompleted = JumpTestID;
        yield return null;
    }

    [UnityTest, Order(10)]
    public IEnumerator DashTest()
    {
        while (TestsCompleted != DashTestID - 1) { yield return null; }
        Task.Run(async () => { await MoveRight(1); }).Wait();
        Task.Run(async () => { await Jump(); }).Wait();
        Task.Run(async () => { await TimeDelay(2); }).Wait();
        Task.Run(async () => { await MoveLeft(1); }).Wait();
        Task.Run(async () => { await Jump(); }).Wait();
        Task.Run(async () => { await TimeDelay(2); }).Wait();
        Assert.IsTrue(true);
        TestsCompleted = DashTestID;
        yield return null;
    }

    [UnityTest, Order(11)]
    public IEnumerator CombatTest()
    {
        while (TestsCompleted != CombatTestID - 1) { yield return null; }
        PlayerRef.transform.position.Set(24, 3, 0);
        Task.Run(async () => { await Fire(); }).Wait();
        Task.Run(async () => { await Fire(); }).Wait();
        Task.Run(async () => { await TimeDelay(15); }).Wait();
        Task.Run(async () => { await Fire(); }).Wait();
        Assert.IsTrue(true);
        TestsCompleted = CombatTestID;
        yield return null;
    }

    [UnityTest, Order(12)]
    public IEnumerator CameraLimitTest()
    {

        while (TestsCompleted != CameraLimitTestID - 1) { yield return null; }
        PlayerRef.transform.position.Set(55, 0, 0);
        Task.Run(async () => { await TimeDelay(5); }).Wait();
        PlayerRef.transform.position.Set(-55, 0, 0);
        Task.Run(async () => { await TimeDelay(5); }).Wait();
        PlayerRef.transform.position.Set(0, 55, 0);
        Task.Run(async () => { await TimeDelay(5); }).Wait();
        PlayerRef.transform.position.Set(0, -55, 0);
        Task.Run(async () => { await TimeDelay(5); }).Wait();
        TestsCompleted = CameraLimitTestID;
        yield return null;
    }


}