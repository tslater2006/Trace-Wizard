# Trace Wizard
Peoplesoft TraceSQL File Analyzer

## Purpose

Trace Wizard is a Windows Based utility that can assist in making sense of TraceSQL files. 

Trace Wizard strives to provide:

* Fast processing.
* Stable environment (large files shouldn't crash)
* An intuitive understanding of the execution path.
 * Allows easy viewing of exception/error locations
 * Accurate timings throughout the execution path
 * Highlights slow calls for ease of performance analysis.
* Specific view for Stack Traces
* Memory monitor in bottom-right to track memory usage

## Requirements

Trace Wizard requires a Windows OS and the .NET Framework (v4.5), it does not current run well under Mono.

## Trace File Settings

There are certain trace settings that work best with Trace Wizard.

You should have the following boxes checked:

* SQL:
 * SQL Statements
 * SQL statement variables
 * SQL connect,disconnect,commit,rollback
 * SQL fetch
 * ALL other SQL API calls except SSBs

* PeopleCode
 * Program Starts
 * External function calls
 * Internal function calls

## Execution Path

### Overview

The Execution Path view allows you to see the various execution calls that occured and what peoplecode functions / sql statements were called and by whom.

Items highlighted in Yellow indicate that somewhere in their branch an exception/stack trace/sql error occured, you can follow the yellow trail(s) all the way to the red item.

Items in red indiciate that they produced an exception/stack trace/sql error, clicking on them should reveal more information in the bottom panel.

### Searching

The execution path view supports searching for function names/line numbers, you can toggle the search box with Ctrl + F, you can also exit out of search with Escape.

### Performance Monitoring

The Execution path is also useful for locating troublesome calls in terms of timing, if a page is slow to load, the proper tracesql and Trace Wizard should make it easy to pinpoint the functions responsible.

To help enable this, you can go to Edit -> Settings and adjust the duration (in seconds) that you would like to consider "slow", after this Trace Wizard will highlight any calls in the Execution Path that exceeded this threshold with a green color.

## SQL Statements

### Overview

The SQL Statements view shows every SQL Statement that was found in the trace file.

Double clicking on an SQL statement will take you to that exact SQL statement in the Execution Path tab.

### ALL View

The ALL view is the default view and will show each individual SQL statement. Clicking on a statement will show you additional information about it in the lower pane including:

* The full statement
* Duration of the call
* Time to execute the call
* Time to fetch the results
* Number of rows fetched
* Number of bind variables
* Values for each bind variable.

### Where View

This view can be accessed by selecting View -> SQL -> By Where Clause

The WHERE view groups the SQL statements by unique Where clause and gives aggregate counts for each group as well as total execution time.

Double clicking one of these items will bring up a pop-up window that contains all of the SQL statements in the group. The information provided on this pop-up is identical to the ALL view.

You can also double click on one of these items to be taken to that specific SQL item in the Execution Path.

### From View

This view can be accessed by selecting View -> SQL -> By From Clause

It operates basically the same to the WHERE view, except it is grouping by FROM statements instead of WHERE

### Errors View

This view can be accessed by selecting View -> SQL -> Errors

This view mode shows any SQL statements that had errors. Double clicking on one of this will take you to the appropriate line in the execution context.

### Tables View

This view can be accessed by selecting View -> SQL -> Errors

This view mode show a list of all tables that where the subject of the "From" clause, and an aggregate count of how many SQL statements used that table.

### Searching

The SQL Statement views supports searching through the SQL Text/line numbers, you can toggle the search box with Ctrl + F, you can also exit out of search with Escape.

## Stack Trace View

This view will show any stack traces that were found in the trace file, again you can click on these for more information or double click to be taken to the location in the execution path where it occurred.

# 3rd Party Code

This project makes use of BSD style licensed code for the Diffing libary. Included below is the License/Copyright for the Diff.cs class.

Copyright (c) 2005-2012 by Matthias Hertel, http://www.mathertel.de/
All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of the copyright owners nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
