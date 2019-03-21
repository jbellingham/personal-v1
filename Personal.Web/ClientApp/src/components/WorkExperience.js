import React from "react"
import { Position } from "./Position"

export class WorkExperience extends React.Component {
  static displayName = WorkExperience.name

  render() {
    const acurusDuties = [
      "Initial development of ANEX Customer Management Portal MVP",
      "Further development of new features and improvements",
      "Assisting junior developers",
      "Reviewing of merge requests",
      "Communicating work progress and blockers with product owner/BAs",
    ]

    const qItDuties = [
      "Development of bug fixes and feature improvements",
      "Maintaining open communication with dev team manager surrounding work item progress and blockers",
      "Ensuring code quality through development of unit tests",
      "Communication with BAs/QA/Service Desk where clarification of work item specs is needed",
    ]

    const idpDuties = [
      `I worked on a contracted development project at IDP for 3 months, building on their online booking system for the IELTS English test.
    Primary work responsibilities included enhancement of existing features, bug fixes, and performance improvement on troublesome areas of the system.`,
    ]

    return (
      <div className="row">
        <div className="wrapper" style={{ width: "900px" }}>
          <h1 className="d-flex justify-content-center">
            ----- Work Experience ------
          </h1>
          <Position
            key="acu"
            positionTitle="Software Developer"
            companyName="Acurus Pty. Ltd."
            startDate="May 2017"
            location="Melbourne, Australia"
            duties={acurusDuties}
            stack={[".Net Core", "React.js"]}
          />
          <Position
            key="qit"
            positionTitle="Software Developer"
            companyName="Quantum I.T."
            startDate="November 2016"
            endDate="May 2017"
            location="Melbourne, Australia"
            duties={qItDuties}
          />
          <Position
            key="idp"
            positionTitle="Software Development Consultant"
            companyName="IDP Education Ltd."
            startDate="November 2016"
            endDate="February 2017"
            location="Melbourne, Australia"
            duties={idpDuties}
          />
          <Position
            key="int"
            positionTitle="Software Developer"
            companyName="Intuto"
            startDate="September 2015"
            endDate="October 2016"
            location="Auckland, NZ"
          />
        </div>
      </div>
    )
  }
}
