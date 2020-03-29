using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Anki.Vector;
using Anki.Vector.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VectorCompanion.Models;

namespace VectorCompanion.Controllers
{
    [Route("vector/{robotname}")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string robotName(string robotname)
        {
            return robotname;
        }
        [HttpGet("message/{text}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async void textToShow(string text, string robotName)
        {
            try
            {
                Debug.Print(robotName);
                using (var robot = await Robot.NewConnection("Vector-" + robotName))
                {
                    await robot.Control.RequestControl();
                    await robot.Behavior.SayText(text);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
        [HttpGet("action/{actionname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async void actionTodo(string actionName, string robotName)
        {
            try
            {
                using (var robot = await Robot.NewConnection("Vector-" + robotName))
                {
                    await robot.Control.RequestControl();
                    switch (actionName)
                    {
                        case "driveoffcharger":
                            await robot.Behavior.DriveOffCharger();
                            break;
                        case "driveoncharger":
                            await robot.Behavior.DriveOnCharger();
                            break;
                        case "dockingwithCube":
                            await robot.World.ConnectCube();
                            if (robot.World.LightCube != null)
                            {
                                await robot.Behavior.DockWithCube(robot.World.LightCube, numRetries: 3);
                                await robot.World.DisconnectCube();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
        [HttpGet("movement/{vitesse}/{actionname}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async void movementTodo(string actionName, string robotName,int vitesse)
        {
            try
            {
                using (var robot = await Robot.NewConnection("Vector-" + robotName))
                {
                    await robot.Control.RequestControl();
                    //robot.Behavior.
                    switch (actionName)
                    {
                        case "forward":
                            await robot.Behavior.DriveStraight(50, 50, true, 3);
                            break;
                        case "backward":
                            await robot.Behavior.DriveStraight(-50, 50, true, 3);
                            break;
                        case "left":
                            await robot.Behavior.TurnInPlace(1);
                            break;
                        case "right":
                            await robot.Behavior.TurnInPlace(-1);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
