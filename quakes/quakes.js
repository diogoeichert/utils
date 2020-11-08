#!/usr/bin/env node

"use strict";

const haversine = require("haversine");
const https = require("https");
const path = require("path");
const Parser = require("parse-json-stream");

const LIMIT = 10;
const UNIT = "km";
const URL = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_month.geojson";

function fetch(origin, callback) {
	const result = [];
	
	const parser = new Parser((error, object) => {
		if (error) {
			console.log(`Ignoring malformed object ${error.message}`);
		} else if (object) {
			if (object.type != "Feature") {
				return;
			}

			const destination = {latitude: object.geometry.coordinates[0], longitude: object.geometry.coordinates[1]};
			object.distance = haversine(origin, destination, {unit: UNIT});
			result.push(object);
		}
	});
	
	https.get(URL, res => {
		res.on("data", data => {
			parser.parse(data);
		});
	
		res.on("end", () => {
			callback(result);
		});
	}).on("error", error => {
		console.log(`Error fetching data from ${URL}`);
		console.log(error.message);
		process.exit(1);
	});	
}

function format(list) {
	return list.map(entry => `${entry.properties.title} || ${Math.floor(entry.distance)}`);
}

function main(args) {
	function usage() {
		const command = path.normalize(program).split("/").pop();
		console.log("Usage:");
		console.log(`${command} latitude longitude`);
		process.exit(1);
	}
	
	if (args.length != 2) {
		usage();
	}
	
	const latitude = parseFloat(args[0]);
	const longitude = parseFloat(args[1]);
	
	if (Number.isNaN(latitude) || Number.isNaN(longitude)) {
		usage();
	}

	fetch({latitude, longitude}, result => {
		format(sort(result)).map(line => console.log(line));
	});
}

function sort(list) {
	return list.sort((a, b) => a.distance - b.distance).slice(0, LIMIT);
}

const [,program, ...args] = process.argv;
main(args);
