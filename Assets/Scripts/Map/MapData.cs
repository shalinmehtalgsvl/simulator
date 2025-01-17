/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulator.Map;

namespace Simulator.Map
{
    public class MapData : MonoBehaviour
    {
        public Color laneColor { get; private set; } = new Color(0f, 1f, 1f, 0.25f);
        public Color whiteLineColor { get; private set; } = new Color(1f, 1f, 1f, 0.25f);
        public Color yellowLineColor { get; private set; } = new Color(1f, 1f, 0f, 0.25f);
        public Color stopLineColor { get; private set; } = new Color(1f, 0f, 0f, 0.25f);
        public Color virtualLineColor { get; private set; } = new Color(1f, 0f, 0.5f, 0.25f);
        public Color stopSignColor { get; private set; } = new Color(0.75f, 0f, 0f, 0.25f);
        public Color junctionColor { get; private set; } = new Color(0.5f, 0.5f, 0.5f, 0.25f);
        public Color poleColor { get; private set; } = new Color(0.5f, 0f, 1f, 0.25f);
        public Color speedBumpColor { get; private set; } = new Color(0.75f, 1f, 0f, 0.25f);
        public Color crossWalkColor { get; private set; } = new Color(1f, 1f, 1f, 1f);
        public Color clearAreaColor { get; private set; } = new Color(0.5f, 0.5f, 0.5f, 1f);
        public Color parkingSpaceColor { get; private set; } = new Color(1f, 0.92f, 0.016f, 1f);
        public Color curbColor { get; private set; } = new Color(0f, 0f, 1f, 0.25f);
        public Color pedestrianColor { get; private set; } = new Color(0f, 1f, 0f, 0.25f);
        public Color intersectionColor { get; private set; } = new Color(1f, 0.5f, 0f, 0.25f);
        public Color tempWaypointColor { get; private set; } = new Color(1f, 0f, 1f, 0.25f);
        public Color targetWaypointColor { get; private set; } = new Color(1f, 1f, 0f, 1f);
        public Color selectedColor { get; private set; } = new Color(0f, 0f, 0f, 0f);

        public enum LaneTurnType // TODO changed to start at 0 index, why 1?
        {
            NO_TURN = 1,
            LEFT_TURN = 2,
            RIGHT_TURN = 3,
            U_TURN = 4
        };

        public enum LaneBoundaryType
        {
            UNKNOWN = 0,
            DOTTED_YELLOW = 1,
            DOTTED_WHITE = 2,
            SOLID_YELLOW = 3,
            SOLID_WHITE = 4,
            DOUBLE_YELLOW = 5,
            CURB = 6
        };

        public enum LineType
        {
            UNKNOWN = -1, // TODO why was this -1 not 0?
            SOLID_WHITE = 0,
            SOLID_YELLOW = 1,
            DOTTED_WHITE = 2,
            DOTTED_YELLOW = 3,
            DOUBLE_WHITE = 4,
            DOUBLE_YELLOW = 5,
            CURB = 6,
            VIRTUAL = 7,
            STOP = 8,
        };

        [System.Serializable]
        public class SignalData
        {
            public Vector3 localPosition = Vector3.zero;
            public SignalColorType signalColor = SignalColorType.Yellow;
        }

        public enum SignalColorType
        {
            Red = 1,
            Yellow = 2,
            Green = 3
        };

        public enum SignalLightStateType
        {
            Red,
            Green,
            Yellow
        };

        public enum SignalType
        {
            UNKNOWN = 1,
            MIX_2_HORIZONTAL = 2,
            MIX_2_VERTICAL = 3,
            MIX_3_HORIZONTAL = 4,
            MIX_3_VERTICAL = 5,
            SINGLE = 6
        };

        public enum SignType
        {
            STOP = 0,
            YIELD = 1,
            // TODO all the signs!
        }

        public virtual void Draw()
        {
            //
        }

        protected virtual void OnDrawGizmos()
        {
    #if UNITY_EDITOR
            if (UnityEditor.Selection.activeGameObject != this.gameObject)
                selectedColor = new Color(0f, 0f, 0f, 0f);
    #endif
            if (MapAnnotationTool.SHOW_MAP_ALL)
                Draw();
        }

        protected virtual void OnDrawGizmosSelected()
        {
            selectedColor = new Color(0f, 0f, 0f, 0.75f);
            if (MapAnnotationTool.SHOW_MAP_SELECTED)
                Draw();
        }

        public static class AnnotationGizmos
        {
            public static void DrawArrowHead(Vector3 start, Vector3 end, Color color, float arrowHeadScale = 1.0f, float arrowHeadLength = 0.02f, float arrowHeadAngle = 13.0f, float arrowPositionRatio = 0.5f)
            {
                var originColor = Gizmos.color;
                Gizmos.color = color;

                var lineVector = end - start;
                var arrowFwdVec = lineVector.normalized * arrowPositionRatio * lineVector.magnitude;
                if (arrowFwdVec == Vector3.zero) return;

                //Draw arrow head
                Vector3 right = (Quaternion.LookRotation(arrowFwdVec) * Quaternion.Euler(arrowHeadAngle, 0, 0) * Vector3.back) * arrowHeadLength;
                Vector3 left = (Quaternion.LookRotation(arrowFwdVec) * Quaternion.Euler(-arrowHeadAngle, 0, 0) * Vector3.back) * arrowHeadLength;
                Vector3 up = (Quaternion.LookRotation(arrowFwdVec) * Quaternion.Euler(0, arrowHeadAngle, 0) * Vector3.back) * arrowHeadLength;
                Vector3 down = (Quaternion.LookRotation(arrowFwdVec) * Quaternion.Euler(0, -arrowHeadAngle, 0) * Vector3.back) * arrowHeadLength;

                Vector3 arrowTip = start + (arrowFwdVec);

                Gizmos.DrawLine(arrowTip, arrowTip + right * arrowHeadScale);
                Gizmos.DrawLine(arrowTip, arrowTip + left * arrowHeadScale);
                Gizmos.DrawLine(arrowTip, arrowTip + up * arrowHeadScale);
                Gizmos.DrawLine(arrowTip, arrowTip + down * arrowHeadScale);

                Gizmos.color = originColor;
            }

            public static void DrawWaypoint(Vector3 point, float pointRadius, Color color)
            {
                Gizmos.color = color;
                Gizmos.DrawSphere(point, pointRadius);
                Gizmos.color = color;
                Gizmos.DrawWireSphere(point, pointRadius);
            }

            public static void DrawCubeWaypoint(Vector3 point, Vector3 size, Color color)
            {
                Gizmos.color = color;
                Gizmos.DrawCube(point, size);
                Gizmos.color = color;
                Gizmos.DrawWireCube(point, size);
            }

            public static void DrawArrowHeads(Transform mainTrans, List<Vector3> localPoints, Color lineColor)
            {
                for (int i = 0; i < localPoints.Count - 1; i++)
                {
                    var start = mainTrans.TransformPoint(localPoints[i]);
                    var end = mainTrans.TransformPoint(localPoints[i + 1]);
                    DrawArrowHead(start, end, lineColor, arrowHeadScale: MapAnnotationTool.ARROWSIZE * 1f, arrowPositionRatio: 0.5f); // TODO why reference map annotation tool?
                }
            }

            public static void DrawLines(Transform mainTrans, List<Vector3> localPoints, Color lineColor)
            {
                var pointCount = localPoints.Count;
                for (int i = 0; i < pointCount - 1; i++)
                {
                    var start = mainTrans.TransformPoint(localPoints[i]);
                    var end = mainTrans.TransformPoint(localPoints[i + 1]);
                    Gizmos.color = lineColor;
                    Gizmos.DrawLine(start, end);
                }
            }

            public static void DrawWaypoints(Transform mainTrans, List<Vector3> localPoints, float pointRadius, Color color)
            {
                var pointCount = localPoints.Count;
                for (int i = 0; i < pointCount - 1; i++)
                {
                    var start = mainTrans.TransformPoint(localPoints[i]);
                    DrawWaypoint(start, pointRadius, color);
                }

                var last = mainTrans.TransformPoint(localPoints[pointCount - 1]);
                DrawWaypoint(last, pointRadius, color);
            }
        }
    }
}
