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

    public void GetTestRefs()
    {
        TestRefs = GameObject.FindGameObjectWithTag("TestData").GetComponent<TestReferenceLedger>();
    }

    public IEnumerator  MoveRight(int frameCount)
    {
        for (int i = frameCount; i > 0; i++)
        {
            PCRef.HorizontalMove(1);
            yield return new WaitForSeconds(FrameConversion(1)); //TimeDelay(1);
        }
    }

    public IEnumerator MoveLeft(int frameCount)
    {
        for (int i = frameCount; i > 0; i++)
        {
            PCRef.HorizontalMove(-1);
            yield return new WaitForSeconds(FrameConversion(1));//TimeDelay(1);
        }
    }

    public IEnumerator Dash()
    {
        PCRef.Dash();
        yield return new WaitForSeconds(FrameConversion(30)); //TimeDelay(30);
    }

    public IEnumerator Jump()
    {
        PCRef.Jump(1);
        yield return new WaitForSeconds(FrameConversion(15)); //TimeDelay(15);
    }

    public IEnumerator Fire()
    {
        if (PCRef.afterShotDelay == 0 && (PCRef.thisRB2D.velocity.x == 0 || PCRef.Crouching))
        {
            PCRef.FireBullet();
        }
        yield return new WaitForSeconds(FrameConversion(1));//TimeDelay(1);
    }


    public IEnumerator TimeDelay(int FrameNum)
    {
        //Thread.Sleep(50 * FrameNum);
        yield return new WaitForSeconds(((float)0.02) * ((float)FrameNum));
        //await Time.Delay()
        //int i = 0;
        //while (i < FrameNum)
        //{
        //    yield return new WaitForEndOfFrame();
        ///    i++;
        //}yield return new WaitForSeconds(FrameConversion());
    }
    
    /*private static async Task<DelayStruct> TimeDelay(int FrameNum)
    { //To use: var DelayStruct = await TimeDelay(number);
        await Task.Delay(FrameNum);
        return new DelayStruct();
    }*/

    public struct DelayStruct
    {

    }

    public float FrameConversion(int FrameNum)
    {
        return ((float)0.02) * ((float)FrameNum);
    }




    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        //KeyboardRef = InputSystem.AddDevice<Keyboard>();
        //MouseRef = InputSystem.AddDevice<Mouse>();
        //EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/DevCell.unity", new LoadSceneParameters(LoadSceneMode.Single));
    }

    [UnityTest, Order(1)]
    public IEnumerator TestingTest()
    {
        Assert.IsTrue(true);
        yield return null;
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
    public IEnumerator StartMenuTest()
    {
        EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/TitleMenu.unity", new LoadSceneParameters(LoadSceneMode.Single));
        //StartCoroutine(DelayAction(delayTime));
        yield return new WaitForSeconds(FrameConversion(50));
        GetTestRefs();
        GameObject StartButton = TestRefs.StartButton;
        Assert.True(StartButton.gameObject.activeSelf);
        yield return new WaitForSeconds(FrameConversion(15));//TimeDelay(15);
        StartButton.GetComponent<Button>().onClick.Invoke();
        Assert.False(StartButton.gameObject.activeSelf);
        yield return null;
    }

    [UnityTest, Order(3)]
    public IEnumerator NewGameTest()
    {
        GameObject NGButton = TestRefs.NewGameButton;
        NGButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(FrameConversion(50));//TimeDelay(50);
        Assert.AreEqual(SceneManager.GetActiveScene().name, "FortCell2");
        yield return null;
    }

    [UnityTest, Order(4)]
    public IEnumerator PlayerVerifyTest()
    {
        GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
        if (PCs.Length != 0)
        {
            PlayerRef = PCs[0];
            Assert.NotNull(PlayerRef);
        }
        else
        {
            Assert.Fail();
        }
        yield return null;
    }

    [UnityTest, Order(5)]
    public IEnumerator CellPathTest()
    {
        //PlayerRef.transform.position.Set(-16, -2, 0);
        //MoveLeft(10);
        for (int i = 100; i > 0; i--)
        {
            PCRef.HorizontalMove(-1);
            yield return new WaitForSeconds(FrameConversion(1));//TimeDelay(1);
        }
        //yield return new WaitForSeconds(0.100f);
        Assert.AreEqual(SceneManager.GetActiveScene().name, "FortCell1");
        yield return null;
    }

    [UnityTest, Order(6)]
    public IEnumerator LoadTestCell()
    {
        EditorSceneManager.LoadSceneInPlayMode("Assets/Scenes/DevCell.unity", new LoadSceneParameters(LoadSceneMode.Single));
        Assert.AreEqual(SceneManager.GetActiveScene().name, "DevCell");
        yield return null;
    }

    [UnityTest, Order(7)]
    public IEnumerator HorizontalMovementTest()
    {
        MoveRight(5);
        MoveLeft(5);
        Assert.IsTrue(true);
        yield return null;
    }

    [UnityTest, Order(8)]
    public IEnumerator JumpTest()
    {
        Jump();
        yield return new WaitForSeconds(FrameConversion(15));
        Jump();
        yield return new WaitForSeconds(FrameConversion(15));
        Jump();
        yield return new WaitForSeconds(FrameConversion(300));
        Assert.IsTrue(true);
        yield return null;
    }

    [UnityTest, Order(9)]
    public IEnumerator DashTest()
    {
        MoveRight(1);
        Jump();
        yield return new WaitForSeconds(FrameConversion(2));
        MoveLeft(1);
        Jump();
        yield return new WaitForSeconds(FrameConversion(2));
        Assert.IsTrue(true);
        yield return null;
    }

    [UnityTest, Order(10)]
    public IEnumerator CombatTest()
    {
        PlayerRef.transform.position.Set(24, 3, 0);
        Fire();
        Fire();
        yield return new WaitForSeconds(FrameConversion(10));
        Fire();
        Assert.IsTrue(true);
        yield return null;
    }

    [UnityTest, Order(11)]
    public IEnumerator CameraLimitTest()
    {
        PlayerRef.transform.position.Set(55, 0, 0);
        yield return new WaitForSeconds(FrameConversion(5));
        PlayerRef.transform.position.Set(-55, 0, 0);
        yield return new WaitForSeconds(FrameConversion(5));
        PlayerRef.transform.position.Set(0, 55, 0);
        yield return new WaitForSeconds(FrameConversion(5));
        PlayerRef.transform.position.Set(0, -55, 0);
        yield return new WaitForSeconds(FrameConversion(5));
        Assert.IsTrue(true);
        yield return null;
    }


}