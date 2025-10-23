// examples https://developers.facebook.com/docs/unity/examples
// preview version 

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

#if (ADDFB)
    using Facebook.Unity;
    using Facebook.MiniJSON;
#endif

/*
 changes:
    13.01.19  public static Action<bool, bool, string> LoginPublishEvent
        fix LogoutEvent
        remove state

    01.05.19
        public static Action<bool, Sprite> LoadPhotoEvent; // logined, photo
        public static Action<bool, string, string> LoadTextEvent;  // logined, first name, last name

    30.08.19
        -add #define NOFB - symbol
    09.03.2020
        - change  NOFB -> ADDFB - symbol  (from player settings)

    04.09.2021
        - fix public_profile
 */

namespace Mkey
{
    public class FFreshly : MonoBehaviour
    {
        public static FFreshly Instance;

        [SerializeField]
        private bool Would= true;
[UnityEngine.Serialization.FormerlySerializedAs("playerID")]
        public string EyelidID;
[UnityEngine.Serialization.FormerlySerializedAs("playerFirstName")]        public string EyelidAfterOver;
[UnityEngine.Serialization.FormerlySerializedAs("playerLastName")]        public string EyelidHurlOver;
[UnityEngine.Serialization.FormerlySerializedAs("playerPhoto")]        public Sprite EyelidLyric;

        private List<string> Masterpiece;
        private int TrulyTryPulse= 10;
        private int EndUntoldBustEatPulse= 10;
[UnityEngine.Serialization.FormerlySerializedAs("LoginEvent")]
        public static Action<bool, string> StingAnvil; // (logined, result)
[UnityEngine.Serialization.FormerlySerializedAs("LoadPhotoEvent")]        public static Action<bool, Sprite> WideLyricAnvil; // logined, photo
[UnityEngine.Serialization.FormerlySerializedAs("LoadTextEvent")]        public static Action<bool, string, string> WidePityAnvil;  // logined, first name, last name
[UnityEngine.Serialization.FormerlySerializedAs("LogoutEvent")]        public static Action AsleepAnvil;

        // saves last player status, can be used to automatically log in (if (LastSessionLogined) FBlogin())
        public static bool HurlEstuaryLogined        {
            get
            {
                if (!PlayerPrefs.HasKey("_fblastlogined_"))
                {
                    PlayerPrefs.SetInt("_fblastlogined_", 0);
                }
                return PlayerPrefs.GetInt("_fblastlogined_") > 0;
            }
            set
            {
                PlayerPrefs.SetInt("_fblastlogined_", (value) ? 1 : 0);
            }
        }
#if (ADDFB)
        #region regular
        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else Instance = this;
            Initialize();
        }

        private void Start()
        {
            // add listeners for login event
            LoginEvent += (logined, result) => {  };
            // if (LastSessionLogined) FBlogin();// as options
        }
        #endregion regular

        #region init
        public void Initialize()
        {
           if(debug) Debug.Log("FB Initialize");
            if (!FB.IsInitialized)
            {
                FB.Init(() =>
                {
                    if (FB.IsInitialized)
                    {
                        if (debug) Debug.Log("Facebook SDK is initialized");
                        FB.ActivateApp(); //Signal an app activation App Event
                    }
                    else
                    {
                        if (debug) Debug.Log("Failed to Initialize Facebook SDK");
                    }

                }, (isUnityShown) =>
                {
                    if (!isUnityShown)
                    {
                        Time.timeScale = 0;// Pause the game - we will need to hide
                    }
                    else
                    {
                        Time.timeScale = 1;// Resume the game - we're getting focus again
                    }

                });
            }
            else
                FB.ActivateApp(); // Already initialized, signal an app activation App Event
        }
        #endregion init

        #region login
        public void FBlogin()
        {
            if (debug) Debug.Log("Try facebook login");
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                if (debug) Debug.Log("Error. Check internet connection!");
                return;
            }
            permissions = new List<string>();
            permissions.Add("public_profile");
            permissions.Add("email");
            permissions.Add("user_friends"); // required appreview
            FB.LogInWithReadPermissions(permissions, (result) =>
            {
                if (FB.IsLoggedIn)
                {
                    playerID = null;
                    playerFirstName = null;
                    playerLastName = null;
                    playerPhoto = null;

                    if (debug) Debug.Log("facebook is logged in, app token :" + AccessToken.CurrentAccessToken.TokenString);
                    LastSessionLogined = true;
                    LoadAllFBData();
                }
                else
                {
                    if (debug) Debug.Log("facebook is not logged in, loginTryCount : " + loginTryCount);
                    if (result.Error != null)
                    {
                        if (debug) Debug.Log(result.Error);
                    }
                    if (!result.Cancelled)
                    {
                        if (loginTryCount-- > 0)
                        {
                            FBlogin(); // try next login
                        }
                        else
                        {
                            loginTryCount = 10;
                        }
                    }
                    else
                    {
                        if (debug) Debug.Log("Login cancelled");
                    }
                }

                LoginEvent?.Invoke(IsLogined, result.Error);
            });
        }

        public void FBlogOut()
        {
            FB.LogOut();
            LastSessionLogined = false;
            StartCoroutine(WaitLogOut(() =>
            {
                if (debug) Debug.Log("IsLogined: " + IsLogined);
                LogoutEvent?.Invoke();
            }));
        }

        public void FBlogOut(Action logOutCallBack)
        {
            FB.LogOut();
            LastSessionLogined = false;
            StartCoroutine(WaitLogOut(() =>
            {
                if (debug) Debug.Log("IsLogined: " + IsLogined);
                LogoutEvent?.Invoke();
                logOutCallBack?.Invoke();
            }));

        }

        IEnumerator WaitLogOut(Action logOutCallBack)
        {
            while (IsLogined)
                yield return null;
            logOutCallBack?.Invoke();
        }

        public static bool IsLogined
        {
            get { return FB.IsLoggedIn; }
        }

        /// <summary>
        /// Run sequence to load user profile, apprequest, friends profiles, invitable friends profiles 
        /// </summary>
        private void LoadAllFBData()
        {
            WeighEke tS = new WeighEke();

            tS.Add((callBack) =>
            {
                GetPlayerTextInfo(callBack);
            });

            tS.Add((callBack) =>
            {
                GetPlayerPhoto(callBack);
            });

            tS.Add((callBack) =>
            {
                callBack?.Invoke();
            });

            tS.Start();
        }
        #endregion login

        #region player info
        /// <summary>
        /// Fetch player first name, last name and id, with try count = getPlayerInfoTryCount 
        /// </summary>
        public void GetPlayerTextInfo(Action completeCallBack)
        {
            WeighEke tS = new WeighEke();
            for (int i = 0; i < getPlayerInfoTryCount; i++)
            {
                tS.Add((callBack) =>
                {
                    TryGetPlayerTextInfo(callBack);
                });
            }

            tS.Add((callBack) =>
            {
                LoadTextEvent?.Invoke(IsLogined, playerFirstName, playerLastName);
                completeCallBack?.Invoke();
            });
            tS.Start();
        }

        /// <summary>
        /// Fetch player first name, id and photo
        /// </summary>
        public void TryGetPlayerTextInfo(Action completeCallBack)
        {
            if (string.IsNullOrEmpty(playerID))
            {
                if (debug) Debug.Log("Try to get player text info...");
                FB.API("/me?fields=first_name,last_name,id,email", HttpMethod.GET,
                    (result) =>
                    {
                        if (result.Error != null)
                        {
                            if (debug) Debug.Log(result.Error);
                        }
                        else
                        {
                            if (result.ResultDictionary.ContainsKey("first_name")) playerFirstName = (string)result.ResultDictionary["first_name"];
                            if (result.ResultDictionary.ContainsKey("last_name")) playerLastName = (string)result.ResultDictionary["last_name"];
                            if (result.ResultDictionary.ContainsKey("id")) playerID = (string)result.ResultDictionary["id"];
                            if (debug) Debug.Log("Player text info received. PlayerName: " + playerFirstName + " " + playerLastName + " ; playerID: " + playerID);

                        }
                        completeCallBack?.Invoke();
                    });
            }
            else
            {
                completeCallBack?.Invoke();
            }
        }

        /// <summary>
        /// Fetch player first name, id and photo
        /// </summary>
        public void GetPlayerPhoto(Action completeCallBack)
        {
            if (string.IsNullOrEmpty(playerID))
            {
                completeCallBack?.Invoke();
                return;
            }

            WeighEke tS = new WeighEke();
            for (int i = 0; i < getPlayerInfoTryCount; i++)
            {
                tS.Add((callBack) =>
                {
                    TryGetPlayerPhoto(callBack);
                });
            }

            tS.Add((callBack) =>
            {
                LoadPhotoEvent?.Invoke(IsLogined, playerPhoto);
                completeCallBack?.Invoke();
                callBack();
            });
            tS.Start();
        }

        /// <summary>
        /// Fetch player first name, id and photo
        /// </summary>
        public void TryGetPlayerPhoto(Action completeCallBack)
        {
            if (playerPhoto == null)
            {
                if (debug) Debug.Log("Try to get player photo...");
                FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, (result) =>
                {
                    if (result.Texture != null)
                    {
                        if (debug) Debug.Log("Player photo received..");
                        playerPhoto = Sprite.Create(result.Texture, new Rect(0, 0, result.Texture.width, result.Texture.height), new Vector2(0.5f, 0.5f));
                    }
                    else
                    {
                        if (debug) Debug.Log("NO player photo, new query: ....");
                    }
                    completeCallBack?.Invoke();
                });
            }
            else
            {
                completeCallBack?.Invoke();
            }
        }
        #endregion player info

        #region app link
        public void GetAppLink()
        {
            if (Constants.IsMobile)
            {
                FB.Mobile.FetchDeferredAppLinkData(this.GetAppLinkCallBack);
                return;
            }
            FB.GetAppLink(this.GetAppLinkCallBack);
        }

        protected void GetAppLinkCallBack(IResult result)
        {
            string LastResponse = string.Empty;
            string Status = string.Empty;
            if (result == null)
            {
                LastResponse = "Null Response\n";
                if (debug) Debug.Log(LastResponse);
                return;
            }

            if (!string.IsNullOrEmpty(result.Error))
            {
                Status = "Error - Check log for details";
                LastResponse = "Error Response:\n" + result.Error;
            }
            else if (result.Cancelled)
            {
                Status = "Cancelled - Check log for details";
                LastResponse = "Cancelled Response:\n" + result.RawResult;
            }
            else if (!string.IsNullOrEmpty(result.RawResult))
            {
                Status = "Success - Check log for details";
                LastResponse = "Success Response:\n" + result.RawResult;
            }
            else
            {
                LastResponse = "Empty Response\n";
            }

            if (debug) Debug.Log(result.ToString());
        }
        #endregion app link

#else
        #region regular
        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else Instance = this;
            Immobilize();
        }

        private void Start()
        {
            // add listeners for login event
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
        }
        #endregion regular

        #region init
        public void Immobilize()
        {
            if (Would) Debug.Log("FB Initialize");
        }
        #endregion init

        #region login
        public void FLizard()
        {
            if (Would) Debug.Log("Try facebook login");
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
            StingAnvil?.Invoke(IDPortend, "no facebook ");
        }

        public void FVaseIts()
        {
            if (Would) Debug.Log("IsLogined: " + IDPortend);
            AsleepAnvil?.Invoke();
        }

        public void FVaseIts(Action logOutCallBack)
        {
            if (Would) Debug.Log("IsLogined: " + IDPortend);
            AsleepAnvil?.Invoke();
            logOutCallBack?.Invoke();

        }

        public static bool IDPortend        {
            get { return false; }
        }

        /// <summary>
        /// Run sequence to load user profile, apprequest, friends profiles, invitable friends profiles 
        /// </summary>
        private void WideJoyFBSoul()
        {
            WeighEke tS = new WeighEke();

            tS.Bat((callBack) =>
            {
                HowUntoldPityBust(callBack);
            });

            tS.Bat((callBack) =>
            {
                HowUntoldLyric(callBack);
            });

            tS.Bat((callBack) =>
            {
                callBack?.Invoke();
            });

            tS.Start();
        }
        #endregion login

        #region player info
        /// <summary>
        /// Fetch player first name, last name and id, with try count = getPlayerInfoTryCount 
        /// </summary>
        public void HowUntoldPityBust(Action completeCallBack)
        {
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
            completeCallBack?.Invoke();
        }

        /// <summary>
        /// Fetch player first name, id and photo
        /// </summary>
        public void EatHowUntoldPityBust(Action completeCallBack)
        {
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
            completeCallBack?.Invoke();
        }

        /// <summary>
        /// Fetch player first name, id and photo
        /// </summary>
        public void HowUntoldLyric(Action completeCallBack)
        {
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
            completeCallBack?.Invoke();
        }

        /// <summary>
        /// Fetch player first name, id and photo
        /// </summary>
        public void EatHowUntoldLyric(Action completeCallBack)
        {
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
            completeCallBack?.Invoke();
        }
        #endregion player info

        #region app link
        public void HowMapBear()
        {
            Debug.Log("ADD ADDFB sripting symbol in project settings and load SDK");
        }
        #endregion app link
#endif
    }
}
