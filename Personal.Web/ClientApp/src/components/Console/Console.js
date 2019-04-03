import React from "react"
import { ConsoleLine } from "./ConsoleLine"

export class Console extends React.Component {
  static displayName = Console.name

  render() {
    return (
      <div className="content console"
        style={{
          backgroundColor: "#383737",
          borderTop: "10px solid #ccc",
          borderBottom: "10px solid #ccc",
          borderRadius: "5px",
        }}
      >
        <ConsoleLine lineTitle="jesse.origin" lineDescription="New Zealand"/>
        <ConsoleLine lineTitle="jesse.currentLocation" lineDescription="Melbourne, Australia" />
        <ConsoleLine
          lineTitle="jesse.education"
          lineDescription="Bachelor of Information Technology (Software Development)"
        />
        <ConsoleLine
          lineTitle="jesse.skills"
          lineDescription="['.Net Core', 'React.js', 'Angular', 'jQuery', 'PostgreSQL']"
        />
        <ConsoleLine
          lineTitle="jesse.interests"
          lineDescription="['coding', 'gaming', 'live music', 'snowboarding', 'powerlifting']"
        />
        <ConsoleLine
          lineTitle="jesse.email"
          lineDescription="jbellingham91@gmail.com"
          lineLink="mailto:jbellingham91@gmail.com"
        />
      </div>
    )
  }
}
